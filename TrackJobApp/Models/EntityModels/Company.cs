namespace TrackJobApp.Models.EntityModels
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public bool? IsDomestic { get; set; }
    }
}
