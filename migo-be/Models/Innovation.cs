using System;
using System.ComponentModel.DataAnnotations;

namespace migo_be.Models
{
    public class Innovation
    {
        [Key]
        public int Id { get; set; }

        public double CA_Q1 { get; set; }
        public double CA_Q2 { get; set; }




    }
}

