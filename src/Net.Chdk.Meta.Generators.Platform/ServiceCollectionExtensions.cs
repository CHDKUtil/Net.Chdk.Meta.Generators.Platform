using Microsoft.Extensions.DependencyInjection;

namespace Net.Chdk.Meta.Generators.Platform
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IPlatformGenerator, PlatformGenerator>();
        }

        public static IServiceCollection AddIxusPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IInnerPlatformGenerator, IxusPlatformGenerator>()
                .AddSingleton<IIxusPlatformGenerator, IxusPlatformGenerator>();
        }

        public static IServiceCollection AddPsEosPlatformGenerator(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IInnerPlatformGenerator, PsEosPlatformGenerator>();
        }
    }
}
