using System;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Services;
using AutoMapper;
using Castle.Core.Logging;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlfredoRevillaRoniAdaTest1.Controllers.Tests
{
    [TestClass()]
    public class JobControllerTests
    {
        private readonly IJobService jobService;
        private readonly IMapper mapper;
        private JobController jobController;

        public JobControllerTests()
        {
            var httpContext = A.Fake<HttpContext>();
            var serviceProvider = A.Fake<IServiceProvider>();
            A.CallTo(() => httpContext.RequestServices)
                .Returns(serviceProvider);
            A.CallTo(() => serviceProvider.GetService(A<Type>.Ignored))
                .WithAnyArguments()
                .Returns(new FakeLoggerFactory());

            jobService = A.Fake<Services.IJobService>();
            mapper = A.Fake<IMapper>();
            jobController = new JobController(jobService, mapper);
        }

        [TestMethod()]
        public async Task GetTest()
        {
            var result = jobController.Get();

            await foreach (var item in result)
            {
            }
        }

        [TestMethod()]
        public async Task CompleteTest()
        {
            var result = await jobController.Complete(Guid.Empty);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod()]
        public async Task GetSummaryTest()
        {
            var result = jobController.GetSummary();
            await foreach (var item in result)
            {
            }
        }
    }

    public class FakeLoggerFactory : ILoggerFactory
    {
        public ILogger Create(Type type)
        {
            throw new NotImplementedException();
        }

        public ILogger Create(string name)
        {
            throw new NotImplementedException();
        }

        public ILogger Create(Type type, LoggerLevel level)
        {
            throw new NotImplementedException();
        }

        public ILogger Create(string name, LoggerLevel level)
        {
            throw new NotImplementedException();
        }
    }
}