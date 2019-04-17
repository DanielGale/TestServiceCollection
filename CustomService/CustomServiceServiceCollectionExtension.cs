using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using TestServiceCollection.CustomService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CustomServiceServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomService(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            // Don't overwrite any options setups that a user may have added.
            services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<CustomServiceOptions>, CustomServiceOptionsSetup>());

            services.TryAddSingleton<ICustomService, DefaultCustomService>();

            return services;
        }
        public static IServiceCollection AddCustomService(this IServiceCollection services, Action<CustomServiceOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.AddCustomService();
            services.Configure(setupAction);

            return services;
        }
    }
}