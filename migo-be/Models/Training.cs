using System;
using System.ComponentModel.DataAnnotations;
using Alliance_API.Models;

namespace migo_be.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String? Url { get; set; }
        public String Category { get; set; }
        public String Aspects { get; set; }
        public List<Employee>? Employees { get; set; }
        
    }
}

