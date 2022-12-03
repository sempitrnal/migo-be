using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace migo_be.Models
{
   
    public class Quality
    {
        [Key]
        public int Id { get; set; }
 

        public double CA_Q1 { get; set; }
        public double CA_Q2 { get; set; }




    }
}