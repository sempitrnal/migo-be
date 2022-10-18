using System;
using System.Text.Json.Serialization;

namespace Alliance_API.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;

        public string Deadline { get; set; } = string.Empty;

        public List<Employee> AssignedEmployees { get; set; }
    }
}

