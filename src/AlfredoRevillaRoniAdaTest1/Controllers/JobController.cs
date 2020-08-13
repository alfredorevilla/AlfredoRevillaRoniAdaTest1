using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlfredoRevillaRoniAdaTest1.Models;
using AlfredoRevillaRoniAdaTest1.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlfredoRevillaRoniAdaTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService jobService;
        private readonly IMapper mapper;

        public JobController(IJobService jobService, IMapper mapper)
        {
            this.jobService = jobService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async IAsyncEnumerable<JobModel> Get([FromQuery] GetJobModel model)
        {
            await foreach (var item in jobService.GetAsync(mapper.Map<GetJobServiceModel>(model)))
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
        public async IAsyncEnumerable<dynamic> GetSummary()
        {
            await foreach (var item in jobService.GetSummaryAsync())
            {
                yield return mapper.Map<JobSummaryItemModel>(item);
            }
        }
    }
}