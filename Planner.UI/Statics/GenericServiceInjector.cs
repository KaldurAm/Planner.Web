using Microsoft.Extensions.DependencyInjection;
using Planner.UI.Interfaces;
using System.Linq;

namespace Planner.UI.Statics
{
    public static class GenericServiceInjector
    {
        public static IServiceCollection InjectGenericInterface(this IServiceCollection services)
        {
            System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(item => item.GetInterfaces()
            .Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IRestService<>)) && !item.IsAbstract && !item.IsInterface)
            .ToList()
            .ForEach(assignedTypes =>
            {
                var serviceType = assignedTypes.GetInterfaces().First(i => i.GetGenericTypeDefinition() == typeof(IRestService<>));
                services.AddScoped(serviceType, assignedTypes);
            });
            return services;
        }
    }
}
