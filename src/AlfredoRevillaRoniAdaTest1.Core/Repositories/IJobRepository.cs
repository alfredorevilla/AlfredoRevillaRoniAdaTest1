using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlfredoRevillaRoniAdaTest1.Repositories
{
    public interface IJobRepository
    {
        IQueryable<JobRepositoryModel> Query();
        Task<JobRepositoryModel> FindAsync(Guid id);
        Task UpdateAsync(JobRepositoryModel model);
    }
}