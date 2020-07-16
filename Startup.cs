using FunctionForTest;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FunctionForTest
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IRepository, Repository>();



            builder.Services.AddLogging();
        }
    }

    public interface IRepository
    {
        string GetData();
    }
    public class Repository : IRepository
    {
        public string GetData()
        {
            return "some data!";
        }
    }
}
