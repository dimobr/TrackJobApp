namespace TrackJobApp.Models.DtoModels
{
    public class JobApplicationDto
    {
        public int? Id { get; set; } 
        public string? Name { get; set; }    
        public DateOnly? ApplicationDate { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public string? Description { get; set; }
    }
}
