using Microsoft.Extensions.DependencyInjection;

namespace ArenaBattle.Tests
{
    public abstract class TestsBase
    {
        protected readonly ServiceProvider ServiceProvider = TestServiceProvider.CreateServiceProvider();
    }
}
