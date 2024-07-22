using ArenaBattle.Factories;
using ArenaBattle.Interfaces.Factories;
using ArenaBattle.Interfaces.Services;
using ArenaBattle.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ArenaBattle.Tests
{
    public static class TestServiceProvider
    {
        public static ServiceProvider CreateServiceProvider()
        {
            var serviceCollection = new ServiceCollection();

            // Register services
            serviceCollection.AddSingleton<IHeroFactory, HeroFactory>();

            serviceCollection.AddScoped<IArenaService, ArenaService>();

            // Build and return the service provider
            return serviceCollection.BuildServiceProvider();
        }
    }
}
