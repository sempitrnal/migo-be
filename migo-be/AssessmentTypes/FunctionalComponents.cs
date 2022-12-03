using System;
using System.ComponentModel.DataAnnotations;

namespace migo_be.AssessmentTypes
{
    public class FunctionalComponents
    {
        [Key]
        public int Id { get; set; }
        public double FC_PE_Q1 { get; set; }
        public double FC_KS_Q1 { get; set; }
        public double FC_TP_Q1 { get; set; }
        public double FC_EC_Q1 { get; set; }
        public double FC_LTS_Q1 { get; set; }
    }
}

