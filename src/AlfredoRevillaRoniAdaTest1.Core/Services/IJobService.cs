using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlfredoRevillaRoniAdaTest1.Services
{
    public interface IJobService
    {
        IAsyncEnumerable<JobServiceModel> GetAsync(GetJobServiceModel getJobServiceModel);

        IAsyncEnumerable<JobSummaryItemServiceModel> GetSummaryAsync();

        Task CompleteAsync(Guid id);
    }
}