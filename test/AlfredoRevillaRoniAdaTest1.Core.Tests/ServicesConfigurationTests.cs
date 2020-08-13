using System;
using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlfredoRevillaRoniAdaTest1.Tests
{
    [TestClass()]
    public class ServicesConfigurationTests
    {
        private IServiceCollection services;

        public ServicesConfigurationTests()
        {
            services = A.Fake<IServiceCollection>();
        }

        [TestMethod()]
        public void AddMappingExpressionTest()
        {
            services.AddMappingExpression(c => c.CreateMap<Tuple<int>, Tuple<int>>());
        }

        [TestMethod()]
        public void AddCoreServicesTest()
        {
            services.AddCoreServices();
        }
    }
}