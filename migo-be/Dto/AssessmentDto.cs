using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Alliance_API.Models;
using Microsoft.EntityFrameworkCore;


namespace migo_be.Models
{

    public class AssessmentDto
    {
       
        [JsonIgnore]
        public Employee? Employee { get; set; }
        [JsonIgnore]
        public int EmployeeId { get; set; }

        public Quality Quality { get; set; }
        [JsonIgnore]
        public int QualityId { get; set; }
        public Innovation Innovation { get; set; }
        public Agility Agility { get; set; }
        public Efficiency Efficiency { get; set; }
        public Integrity Integrity { get; set; }

        public FunctionalComponents FunctionalComponents { get; set; }
        public Performance Performance { get; set; }
   
    }
}

