using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Alliance_API.Models;
using migo_be.AssessmentTypes;

namespace migo_be.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }

        public Quality Quality { get; set; }
        public Innovation Innovation { get; set; }
        public Agility Agility { get; set; }
        public Efficiency Efficiency { get; set; }
        public Integrity Integrity { get; set; }

        public FunctionalComponents FunctionalComponents { get; set; }
        public Performance Performance { get; set; }


    }
}

