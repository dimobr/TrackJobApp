using TrackJobApp.Enums;

namespace TrackJobApp.Models.EntityModels
{
    public class JobApplication : BaseEntity
    {
        public string? PositionName { get; set; }
        public Company? Company { get; set; }
        public Location? Location { get; set; }
        public Uri? ListedOnSite { get; set; }
        public DateOnly? ApplicationDate { get; set; }
        public ApplicationStatuses? Status { get; set; }
        public string? StatusAsString { get; set; }
        public string? Notes { get; set; }
        public PositionDescription? Description { get; set; }
    }
}
