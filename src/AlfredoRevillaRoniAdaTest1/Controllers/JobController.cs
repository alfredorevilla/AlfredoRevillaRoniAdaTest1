using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Models;
using AlfredoRevillaRoniAdaTest1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlfredoRevillaRoniAdaTest1.Controllers
{
    [Route("api/jobs")]
    [ApiController]
    public class JobController : ControllerBase
    {
        public readonly static Action<IMapperConfigurationExpression> MappingExpression = c =>
        {
            c.CreateMap<JobServiceModel, JobModel>()
            .ForMember(d => d.RoomTypeName, o => o.MapFrom(s => s.RoomType.Name));
            c.CreateMap<JobSummaryItemServiceModel, JobSummaryItemModel>()
            .ForMember(d => d.RoomTypeName, o => o.MapFrom(s => s.RoomType.Name));
        };

        private readonly IJobService jobService;
        private readonly IMapper mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            this.jobService = jobService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async IAsyncEnumerable<JobModel> Get()
        {
            await foreach (var item in jobService.GetAsync())
            {
                yield return mapper.Map<JobModel>(item);
            }
        }

        [HttpPost("{id}/complete")]
        public async Task<IActionResult> Complete([FromRoute] Guid id)
        {
            await jobService.CompleteAsync(id);
            return Ok();
        }

        [HttpGet("summary")]
        public async IAsyncEnumerable<JobSummaryItemModel> GetSummary()
        {
            await foreach (var item in jobService.GetSummaryAsync())
            {
                yield return mapper.Map<JobSummaryItemModel>(item);
            }
        }
    }
}