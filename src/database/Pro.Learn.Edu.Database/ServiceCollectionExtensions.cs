using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Pro.Learn.Edu.Database
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
