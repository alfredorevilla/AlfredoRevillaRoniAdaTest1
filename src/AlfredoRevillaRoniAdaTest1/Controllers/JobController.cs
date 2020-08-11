using System.Collections.Generic;
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
        [Produces("application/json")]
        public async IAsyncEnumerable<JobModel> Get([FromQuery] GetJobModel model)
        {
            await foreach (var item in jobService.GetAsync(mapper.Map<GetJobServiceModel>(model)))
            {
                yield return mapper.Map<JobModel>(item);
            }
        }
    }
}