using System.Linq;
using AlfredoRevillaRoniAdaTest1.Repositories;

namespace AlfredoRevillaRoniAdaTest1.Ef
{
    public class JobRepository : IJobRepository
    {
        private readonly Test1DbContext dbContext;

        public JobRepository(Test1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<JobRepositoryModel> Query()
        {
            return dbContext.Jobs;
        }
    }
}