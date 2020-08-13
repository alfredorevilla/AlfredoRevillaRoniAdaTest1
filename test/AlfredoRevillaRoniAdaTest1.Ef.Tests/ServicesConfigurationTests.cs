using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlfredoRevillaRoniAdaTest1.Ef.Tests
{
    [TestClass()]
    public class ServicesConfigurationTests
    {
        private readonly IServiceCollection services;

        public ServicesConfigurationTests()
        {
            services = A.Fake<IServiceCollection>();
        }

        [TestMethod()]
        public void AddEfServicesTest()
        {
            services.AddEfServices(o => o.UseInMemoryDatabase("db"));
        }
    }
}