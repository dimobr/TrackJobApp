using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrackJobApp.Models.DtoModels;
using TrackJobApp.Services.Samples;

namespace TrackJobApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobApplicationController : ControllerBase
    {
        private readonly ILogger<JobApplicationController> _logger;
        private readonly IJobApplicationService _jobApplicationService;

        public JobApplicationController(ILogger<JobApplicationController> logger,
            IJobApplicationService jobApplicationService)
        {
            _logger = logger;
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet(Name = "GetJobApplications")]
        public IEnumerable<JobApplicationDto> Get()
        {
            var jobApplications = _jobApplicationService.GetApplications();

            return jobApplications.Select(jobApplicationEntity => new JobApplicationDto() 
            {
                Id = jobApplicationEntity.Id,
                Name = jobApplicationEntity.PositionName,
                ApplicationDate = jobApplicationEntity.ApplicationDate,
                Status = jobApplicationEntity.StatusAsString,
                Notes = jobApplicationEntity.Notes,
                Description = jobApplicationEntity.Description?.DescriptionText
            });
        }
    }
}
