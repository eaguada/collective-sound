using AutoMapper;
using CollectiveSound.Utils.Extensions.Collections;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CollectiveSound.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureNucleusApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServiceCollectionExtensions));

            services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
                .Where(c => c.Name.EndsWith("AppService"))
                .AsPublicImplementedInterfaces();

            return services;
        }
    }
}
