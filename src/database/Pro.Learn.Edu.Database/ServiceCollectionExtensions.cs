using Microsoft.EntityFrameworkCore;
using Pro.Learn.Edu.Database;
using System;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProLearnEduDatabase(
            this IServiceCollection services, Action<DbContextOptionsBuilder> dbContextOptionsBuilderAction = null)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddDbContext<DatabaseContext>(options => dbContextOptionsBuilderAction?.Invoke(options));

            return services;
        }
    }
}
