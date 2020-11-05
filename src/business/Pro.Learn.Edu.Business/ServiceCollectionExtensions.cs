using FluentValidation;
using MediatR;
using Pro.Learn.Edu.Business.Pipeline;
using Pro.Learn.Edu.Database;
using Pro.Learn.Edu.Database.Entity;
using System.Linq;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProLearnEduBusiness(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //var assembly = MethodBase.GetCurrentMethod().DeclaringType.Assembly;
            //foreach (var implementationType in assembly.ExportedTypes.Where(t => t.IsClass && !t.IsAbstract))
            //foreach (var serviceType in implementationType.GetInterfaces()
            //    .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IValidator<>)))
            //    services.AddSingleton(serviceType, implementationType);
            return services;
        }
    }
}
