using System;
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
            try
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
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
            
            return Enumerable.Empty<JobApplicationDto>();   
        }

        [HttpGet(Name = "GetJobApplicationById")]
        public JobApplicationDto GetJobApplicationById(int id)
        {
            var application = _jobApplicationService.GetApplicationById(id);

            if (application is null) 
            {
                _logger.LogInformation("A job applicaiton item with the corresponding ID could not be found.");
                return new JobApplicationDto() { };
            }

            return new JobApplicationDto()
            {
                Id = application.Id,
                Name = application.PositionName,
                ApplicationDate = application.ApplicationDate,
                Status = application.StatusAsString,
                Notes = application.Notes,  
                Description = application.Description?.DescriptionText
            };
        }
    }
}
