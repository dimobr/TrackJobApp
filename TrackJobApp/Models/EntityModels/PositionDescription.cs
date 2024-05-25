namespace TrackJobApp.Models.EntityModels
{
    public class PositionDescription : BaseEntity
    {
        public Uri? ImagePath { get; set; }
        public string? DescriptionText { get; set; }
    }
}
