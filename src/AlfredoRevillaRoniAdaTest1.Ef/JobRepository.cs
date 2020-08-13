using System;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AlfredoRevillaRoniAdaTest1.Ef
{
    public class JobRepository : IJobRepository
    {
        private readonly ILogger<JobRepository> logger;
        private readonly Test1DbContext dbContext;

        public JobRepository(
            ILogger<JobRepository> logger,
            Test1DbContext dbContext
            )
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<JobRepositoryModel> FindAsync(Guid id)
        {
            logger.LogTrace("Finding job with id {0}.", id);

            var result = await dbContext.FindAsync<JobRepositoryModel>(id);
            if (result == null)
            {
                logger.LogWarning("Job not found. Raising error.");
                throw new ObjectNotFoundException("Job", id.ToString());
            }

            return result;
        }

        public IQueryable<JobRepositoryModel> Query()
        {
            logger.LogTrace("Returning job query.");

            return dbContext.Jobs.Include(m => m.RoomType);
        }

        public async Task UpdateAsync(JobRepositoryModel model)
        {
            logger.LogTrace("Updating job with id {0}.", model.Id);

            var entry = dbContext.Entry(model);
            if (entry.State == EntityState.Detached)
            {
                logger.LogTrace("Entry is detached. Attaching and setting it as modified.");
                dbContext.Attach(model);
                entry.State = EntityState.Modified;
            }
            logger.LogDebug("Saving changes.");
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Job has been updated.");
        }
    }
}