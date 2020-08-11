using System.Linq;

namespace AlfredoRevillaRoniAdaTest1.Repositories
{
    public interface IJobRepository
    {
        IQueryable<JobRepositoryModel> Query();
    }
}