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
        public String QualityRemark { get; set; }

        public Innovation Innovation { get; set; }
        public String InnovationRemark { get; set; }
        public Agility Agility { get; set; }
        public String AgilityRemark { get; set; }
        public Efficiency Efficiency { get; set; }
        public String EfficiencyRemark { get; set; }
        public Integrity Integrity { get; set; }
        public String IntegrityRemark { get; set; }

        public FunctionalComponents FunctionalComponents { get; set; }
        public String FunctionalComponentsRemark { get; set; }
        public Performance Performance { get; set; }
        public String PerformanceRemark { get; set; }

    }
}

