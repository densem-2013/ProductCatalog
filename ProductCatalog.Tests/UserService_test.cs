using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ProductCatalog.DAL;
using ProductCatalog.Services.Abstract;
using ProductCatalog.Services.Concrete;
using System;
using System.Threading.Tasks;

namespace ProductCatalog.Tests
{
    public class Tests
    {
        private IServiceProvider serviceProvider;

        [SetUp]
        public void Setup()
        {
            var dirpath = AppDomain.CurrentDomain.BaseDirectory;

            var settingsPath = dirpath.Replace("\\ProductCatalog.Tests\\bin\\Debug\\netcoreapp3.1", "\\ProductCatalog.WebApi");

            var appConfiguration = TestHelper.GetApplicationConfiguration(settingsPath);

            var configuration = TestHelper.GetIConfigurationRoot(settingsPath);

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient(typeof(DataContext), (sp) => new DataContext(configuration));

            serviceCollection.AddTransient<IUserService, UserService>();

            serviceProvider = serviceCollection.BuildServiceProvider().CreateScope().ServiceProvider;

        }

        [Test]
        public async Task Authenticate_test()
        {
            var userService = serviceProvider.GetRequiredService<IUserService>();

            var user = await userService.Authenticate("admin", "admin");

            Assert.IsNotNull(user);
        }
    }
}