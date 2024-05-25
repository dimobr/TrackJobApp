using TrackJobApp.Models.EntityModels;
using TrackJobApp.Models.DtoModels;

namespace TrackJobApp.Services.Samples
{
    public interface IJobApplicationService
    {
        IEnumerable<JobApplication> GetApplications();
        JobApplication GetApplicationById(int id);
    }
}
