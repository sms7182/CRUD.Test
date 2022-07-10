using Car.Application.BaseCommandQueryHandler;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Car.Application
{
    public static class ApplicationServiceConfiguration
    {
        private static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
        {
            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                {
                    services.AddTransient(handlerType.AsType(), type.AsType());
                }

               
            }

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {

          
            services.AddMediatR(typeof(BaseCommandHandler<,,>));

            services.AddMediatorHandlers(typeof(BaseCommandHandler<,,>).Assembly);

            return services;
        }
    }
}
