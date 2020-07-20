using Microsoft.Extensions.Configuration;

namespace ProductCatalog.Tests
{
    public static class TestHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static AppConfiguration GetApplicationConfiguration(string outputPath)
        {
            var configuration = new AppConfiguration();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("ConnectionStrings")
                .Bind(configuration);

            return configuration;
        }
    }
}
