using System.ComponentModel.DataAnnotations;
using TrackJobApp.Enums;

namespace TrackJobApp.Models.EntityModels
{
    public class Location : BaseEntity
    {
        public string? FullLocation { get; set; }
        public string? StreetName { get; set; }
        public int? StreetNumber { get; set; }   
        public int? ZipCode { get; set; }
        public string? City { get; set; }   
        public string? Region { get; set; }
        public string? Country { get; set; } 
        public LocationTypes? LocationType { get; set; }
    }
}
