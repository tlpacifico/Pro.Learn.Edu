using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Pro.Learn.Edu.Database.Migrator
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            ILogger<Program> logger = null;
            try
            {
                Console.WriteLine("Configuring application logging");

                var nlogFilePath = Path.Combine(Directory.GetCurrentDirectory(), "nlog.config");

                using var loggerFactory = NLog.LogManager.LoadConfiguration(nlogFilePath);

                NLog.GlobalDiagnosticsContext.Set(
                    "majorVersion", Properties.FileVersionInfo.FileMajorPart.ToString(CultureInfo.InvariantCulture));
                NLog.GlobalDiagnosticsContext.Set(
                    "fileVersion", Properties.FileVersionInfo.FileVersion);
                NLog.GlobalDiagnosticsContext.Set(
                    "productVersion", Properties.FileVersionInfo.ProductVersion);

                using var host = new HostBuilder()
                    .ConfigureHostConfiguration(b =>
                    {
                        b.SetBasePath(Directory.GetCurrentDirectory());
                        b.AddJsonFile("hostsettings.json", false);
                        b.AddEnvironmentVariables("DATABASE_MIGRATOR_");
                        b.AddCommandLine(args);
                    })
                    .ConfigureLogging(b =>
                    {
                        b.AddConsole(o => o.IncludeScopes = true);
                        b.AddDebug();
                        b.AddNLog();
                        b.SetMinimumLevel(LogLevel.Trace);
                    })
                    .ConfigureAppConfiguration((ctx, b) =>
                    {
                        b.SetBasePath(Directory.GetCurrentDirectory());
                        b.AddJsonFile("appsettings.json", false);
                        b.AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", true);
                        b.AddEnvironmentVariables("DATABASE_MIGRATOR_");
                        b.AddCommandLine(args);
                    })
                    .ConfigureServices((ctx, services) =>
                    {
                        services.AddProLearnEduDatabase(o =>
                        {
                            o.UseMySql(
                               ctx.Configuration.GetConnectionString("ProLearnEduContext"),
                               sqlOptions => sqlOptions.MigrationsAssembly(typeof(Program).Assembly.FullName));
                        });
                        services.AddHostedService<ProgramHost>();
                    })
                    .Build();

                logger = host.Services.GetRequiredService<ILogger<Program>>();

                await host.StartAsync();

                await host.StopAsync();

                loggerFactory.Flush();

                return 0;
            }
            catch (Exception e)
            {
                if (logger == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Application failed with a fatal error");
                    Console.WriteLine(e);
                    Console.ResetColor();
                }
                else
                    logger.LogCritical(e, "Application failed with a fatal error");

                return 1;
            }
        }

        public static class Properties
        {
            private static FileVersionInfo _fileVersionInfo;

            public static FileVersionInfo FileVersionInfo
            {
                get
                {
                    if (_fileVersionInfo != null)
                        return _fileVersionInfo;

                    var assemblyLocation = typeof(Program).GetTypeInfo().Assembly.Location;
                    if (string.IsNullOrWhiteSpace(assemblyLocation))
                        throw new InvalidOperationException("Failed to get the assembly location");

                    _fileVersionInfo = FileVersionInfo.GetVersionInfo(assemblyLocation);

                    return _fileVersionInfo;
                }
            }
        }
    }
}
