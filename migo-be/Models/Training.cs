using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Alliance_API.Models;

namespace migo_be.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String? Url { get; set; }
        public String Category { get; set; }
        public int Aspects { get; set; }
        public List<Employee>? Employees { get; set; }
        public string? ImageName { get; set; } = string.Empty;
        [NotMapped]
        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string? ImageSrc { get; set; }
    }
}

