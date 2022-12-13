using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alliance_API.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;

        public string Deadline { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Employee>? AssignedEmployees { get; set; }


        public string? ImageName { get; set; } = string.Empty;

        [NotMapped]
        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string? ImageSrc { get; set; }

    }
}

