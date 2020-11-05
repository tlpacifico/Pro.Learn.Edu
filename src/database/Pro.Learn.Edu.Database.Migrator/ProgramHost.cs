using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Pro.Learn.Edu.Database
{
    public class ProgramHost : IHostedService
    {
        private readonly ILogger<ProgramHost> _logger;
        private readonly DatabaseContext _context;

        public ProgramHost(
            ILogger<ProgramHost> logger,
            DatabaseContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public async Task StartAsync(CancellationToken ct)
        {
            await SetDatabaseLockAsync(true, ct);

            await MigrateDatabaseAsync(ct);

            await SeedInitialDataAsync("Migrations", DateTimeOffset.Now, ct);
        }

        public Task StopAsync(CancellationToken ct) => Task.CompletedTask;

        private async Task SetDatabaseLockAsync(bool enable, CancellationToken ct)
        {
#warning Change queries to database implementation or remove this warning
            if (enable)
            {
                _logger.LogInformation("Setting a global database lock");

                // Mysql Server
                //await _context.Database.ExecuteSqlRawAsync(
                //    $"ALTER DATABASE {_context.Database.GetDbConnection().Database} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", ct);

                _logger.LogWarning("Global database lock was set");
            }
            else
            {
                _logger.LogInformation("Removing global database lock");

                // Mysql Server
                //await _context.Database.ExecuteSqlRawAsync(
                //    $"ALTER DATABASE {_context.Database.GetDbConnection().Database} SET MULTI_USER", ct);

                _logger.LogInformation("Global database lock was removed");
            }
        }

        private async Task MigrateDatabaseAsync(CancellationToken ct)
        {
            _logger.LogDebug("Checking if there are any pending migrations to be applied");

            var pendingMigrations = (await _context.Database.GetPendingMigrationsAsync(ct)).ToList();

            if (pendingMigrations.Count == 0)
                _logger.LogDebug("The are no pending migrations to be applied");
            else
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug(
                        "A total of {pendingMigrationsCount} migrations will be applied to the database [PendingMigrations: {pendingMigrations}]",
                        pendingMigrations.Count, string.Join(", ", pendingMigrations));
                await _context.Database.MigrateAsync(ct);
            }

            _logger.LogInformation("Database migrated to latest version");
        }

        private async Task SeedInitialDataAsync(string by, DateTimeOffset on, CancellationToken ct)
        {
            _logger.LogDebug("Seeding database");

            await using var tx = await _context.Database.BeginTransactionAsync(ct);

            // TODO seed your initial data

            _logger.LogDebug("Saving database changes");

            await _context.SaveChangesAsync(ct);
            tx.Commit();

            _logger.LogInformation("Database seeded");
        }
    }
}