using System;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Repositories;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlfredoRevillaRoniAdaTest1.Ef.Tests
{
    [TestClass()]
    public class JobRepositoryTests
    {
        private readonly Test1DbContext dbContext;
        private readonly JobRepository jobRepository;

        public JobRepositoryTests()
        {
            dbContext = new Test1DbContext(
                    new DbContextOptionsBuilder<Test1DbContext>()
                    .UseInMemoryDatabase("db").Options
                    );

            jobRepository = new JobRepository(
                A.Fake<ILogger<JobRepository>>(),
                dbContext
                );
        }

        [TestMethod()]
        public async Task FindAsyncTest()
        {
            var model = new JobRepositoryModel { Id = Guid.NewGuid() };
            dbContext.Jobs.Add(model);
            await dbContext.SaveChangesAsync();

            var result = await jobRepository.FindAsync(model.Id);

            Assert.AreEqual(model.Id, result.Id);
        }

        [TestMethod()]
        [ExpectedException(typeof(ObjectNotFoundException))]
        public async Task FindAsyncFailsWithObjectNotFound()
        {
            await jobRepository.FindAsync(Guid.NewGuid());
        }

        [TestMethod()]
        public void QueryTest()
        {
            Assert.IsNotNull(jobRepository.Query());
        }

        [TestMethod()]
        public async Task UpdateAsyncTestAsync()
        {
            var model = new JobRepositoryModel { Id = Guid.NewGuid() };
            dbContext.Jobs.Add(model);
            await dbContext.SaveChangesAsync();

            model.Status = "S";
            await jobRepository.UpdateAsync(model);

            model = await jobRepository.FindAsync(model.Id);
            Assert.AreEqual("S", model.Status);
        }
    }
}