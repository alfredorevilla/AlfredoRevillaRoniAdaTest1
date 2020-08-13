using System.Collections.Generic;

namespace AlfredoRevillaRoniAdaTest1.Services
{
    public interface IJobService
    {
        IAsyncEnumerable<JobServiceModel> GetAsync(GetJobServiceModel getJobServiceModel);
        IAsyncEnumerable<JobSummaryItemServiceModel> GetSummaryAsync();
    }
}