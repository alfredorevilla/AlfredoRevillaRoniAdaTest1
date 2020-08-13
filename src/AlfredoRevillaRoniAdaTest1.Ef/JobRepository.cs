using System;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AlfredoRevillaRoniAdaTest1.Ef
{
    public class JobRepository : IJobRepository
    {
        private readonly Test1DbContext dbContext;

        public JobRepository(Test1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<JobRepositoryModel> FindAsync(Guid id)
        {
            var result = await dbContext.FindAsync<JobRepositoryModel>(id);
            if (result == null)
            {
                throw new ObjectNotFoundException("Job", id.ToString());
            }

            return result;
        }

        public IQueryable<JobRepositoryModel> Query()
        {
            return dbContext.Jobs.Include(m => m.RoomType);
        }

        public Task UpdateAsync(JobRepositoryModel model)
        {
            var entry = dbContext.Entry(model);
            if (entry.State == EntityState.Detached)
            {
                dbContext.Attach(model);
            }
            return dbContext.SaveChangesAsync();
        }
    }
}