using Microsoft.Extensions.DependencyInjection;
using System;

namespace Net.Chdk.Meta.Generators.Platform
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IPlatformGenerator, PlatformGenerator>();
        }

        [Obsolete]
        public static IServiceCollection AddIxusPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IInnerPlatformGenerator, IxusPlatformGenerator>()
                .AddSingleton<IIxusPlatformGenerator, IxusPlatformGenerator>();
        }

        [Obsolete]
        public static IServiceCollection AddPsEosPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IInnerPlatformGenerator, PsEosPlatformGenerator>();
        }

        public static IServiceCollection AddPsPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IInnerPlatformGenerator, PowerShotPlatformGenerator>()
                .AddSingleton<IInnerPlatformGenerator, IxusPlatformGenerator>()
                .AddSingleton<IIxusPlatformGenerator, IxusPlatformGenerator>()
                .AddSingleton<IInnerPlatformGenerator, PsEosPlatformGenerator>();
        }
    }
}
