using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CollectiveSound.Utils.Extensions.Collections
{
    public static class ServiceCollectionExtensions
    {

        public static AutoRegisterData RegisterAssemblyPublicNonGenericClasses(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var allPublicTypes = assemblies
                .SelectMany(x =>
                    x.GetExportedTypes()
                        .Where(y => y.IsClass && !y.IsAbstract && !y.IsGenericType && !y.IsNested));

            return new AutoRegisterData(services, allPublicTypes);
        }

        public static AutoRegisterData Where(this AutoRegisterData autoRegisterData, Func<Type, bool> predicate)
        {
            if (autoRegisterData == null)
            {
                throw new ArgumentNullException(nameof(autoRegisterData));
            }
            autoRegisterData.TypeFilter = predicate;

            return new AutoRegisterData(autoRegisterData.Services, autoRegisterData.TypesToConsider.Where(predicate));
        }

        public static IServiceCollection AsPublicImplementedInterfaces(
            this AutoRegisterData autoRegisterData,
            ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            if (autoRegisterData == null)
            {
                throw new ArgumentNullException(nameof(autoRegisterData));
            }

            var classTypes = autoRegisterData.TypeFilter == null
                ? autoRegisterData.TypesToConsider
                : autoRegisterData.TypesToConsider.Where(autoRegisterData.TypeFilter);

            foreach (var classType in classTypes)
            {
                var interfaces = classType.GetTypeInfo().ImplementedInterfaces
                    .Where(i => i != typeof(IDisposable) && i.IsPublic);

                foreach (var interInterface in interfaces)
                {
                    autoRegisterData.Services.Add(new ServiceDescriptor(interInterface, classType, lifetime));
                }
            }

            return autoRegisterData.Services;
        }
    }

    public class AutoRegisterData
    {

        public AutoRegisterData(IServiceCollection services, IEnumerable<Type> typesToConsider)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
            TypesToConsider = typesToConsider ?? throw new ArgumentNullException(nameof(typesToConsider));
        }

        public IServiceCollection Services { get; }

        public IEnumerable<Type> TypesToConsider { get; }


        public Func<Type, bool> TypeFilter { get; set; }
    }
}
