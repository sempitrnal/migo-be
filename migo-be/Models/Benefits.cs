using migo_be.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Alliance_API.Models
{
    public class Benefits
    {
        [Key]
        public int Id { get; set; }



        public string Name { get; set; } = string.Empty;

        public Double Duration { get; set; } = 0.0;

        public string BenefitType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;


        public string? ImageName { get; set; } = string.Empty;

        [NotMapped]
        [JsonIgnore]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        [JsonIgnore]
        public string? ImageSrc { get; set; }

    }
}

