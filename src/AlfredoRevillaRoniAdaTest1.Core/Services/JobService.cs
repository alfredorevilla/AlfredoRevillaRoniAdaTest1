using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Repositories;
using AutoMapper;

namespace AlfredoRevillaRoniAdaTest1.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public JobService(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public async IAsyncEnumerable<JobServiceModel> GetAsync(GetJobServiceModel getJobServiceModel)
        {
            var query = jobRepository
                .Query()
                .ToList();

            foreach (var item in query)
            {
                yield return mapper.Map<JobServiceModel>(item);
            }

            await Task.CompletedTask;
        }
    }
}