using System;
using System.ComponentModel.DataAnnotations;

namespace migo_be.AssessmentTypes
{
    public class Performance
    {
        [Key]
        public int Id { get; set; }
        public double P_A_Q1 { get; set; }
        public double P_B_Q1 { get; set; }
        public double P_C_Q1 { get; set; }
        public double P_D_Q1 { get; set; }
        public double P_E_Q1 { get; set; }
    }
}

