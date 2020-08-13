using System;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Repositories;
using AutoMapper;
using Castle.Core.Logging;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlfredoRevillaRoniAdaTest1.Services.Tests
{
    [TestClass()]
    public class JobServiceTests
    {
        private readonly IJobRepository jobRepository;
        private readonly JobService jobService;

        public JobServiceTests()
        {
            jobRepository = A.Fake<IJobRepository>();

            jobService = new JobService(
                A.Fake<ILogger<JobService>>(),
                jobRepository,
                A.Fake<IMapper>()
                );
        }

        [TestMethod()]
        public async Task GetAsyncTest()
        {
            var result = jobService.GetAsync();

            await foreach (var item in result)
            {
            }
        }

        [TestMethod()]
        public async Task GetSummaryAsyncTest()
        {
            var result = jobService.GetSummaryAsync();

            await foreach (var item in result)
            {
            }
        }

        [DataTestMethod]
        [DataRow("In Progress")]
        [DataRow("Delayed")]
        public async Task CompleteAsyncTest(string status)
        {
            var id = Guid.NewGuid();

            A.CallTo(() => jobRepository.FindAsync(id))
                .Returns(new JobRepositoryModel { Status = status });

            await jobService.CompleteAsync(id);
        }

        [DataTestMethod]
        [DataRow("A")]
        [DataRow("B")]
        [ExpectedException(typeof(InvalidOperationException))]
        public async Task CompleteAsyncFailsWithInvalidOperation(string status)
        {
            var id = Guid.NewGuid();

            A.CallTo(() => jobRepository.FindAsync(id))
                .Returns(new JobRepositoryModel { Status = status });

            await jobService.CompleteAsync(id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CompleteAsyncFailsDueBadArgument()
        {
            await jobService.CompleteAsync(Guid.Empty);
        }
    }
}