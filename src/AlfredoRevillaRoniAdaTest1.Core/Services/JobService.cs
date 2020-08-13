using System;
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
            var list = ListInternal();

            foreach (var item in list)
            {
                yield return mapper.Map<JobServiceModel>(item);
            }

            await Task.CompletedTask;
        }

        private IEnumerable<JobRepositoryModel> ListInternal()
        {
            return jobRepository
                .Query()
                .ToList();
        }

        public async IAsyncEnumerable<JobSummaryItemServiceModel> GetSummaryAsync()
        {
            var collection = ListInternal()
                .GroupBy(
                    o => o.RoomType,
                    (k, c) => new
                    {
                        Key = k,
                        Items = c.OrderBy(co => co.Status).GroupBy(co => co.Status)
                    });

            foreach (var item1 in collection)
            {
                foreach (var item2 in item1.Items)
                {
                    yield return new JobSummaryItemServiceModel
                    {
                        RoomType = mapper.Map<RoomTypeServiceModel>(item1.Key),
                        Count = item2.Count(),
                        Status = item2.Key
                    };
                }
            }

            await Task.CompletedTask;
        }

        public async Task CompleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException(nameof(id));
            }

            var model = await jobRepository.FindAsync(id);

            if (model.Status == "In Progress" || model.Status == "Delayed")
            {
                model.Status = "Complete";
                await jobRepository.UpdateAsync(model);
            }
            else
            {
                throw new InvalidOperationException("Cannot complete due current job status.");
            }
        }
    }
}