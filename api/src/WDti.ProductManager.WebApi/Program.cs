using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using MonteOlimpo.Base.Extensions.Configuration;

namespace WDti.ProductManager.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration(ConfigurationExtensions.AddMonteOlimpoConfiguration)
                .UseStartup<Startup>();
    }
}
