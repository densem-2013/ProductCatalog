using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProductCatalog.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
          .ConfigureLogging((hostingContext, logging) =>
          {
              logging.ClearProviders()
                .AddConfiguration(hostingContext.Configuration.GetSection("Logging"))
                .SetMinimumLevel(LogLevel.Information);
          });
    }
}
