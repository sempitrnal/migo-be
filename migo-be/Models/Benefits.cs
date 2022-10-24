using migo_be.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alliance_API.Models
{
    public class Benefits
    {
        [Key]
        public int Id { get; set; }

        public string Picture { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public Double Duration { get; set; } = 0.0;

        public string BenefitType { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

    }
}

