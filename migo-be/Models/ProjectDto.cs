using System;
using Alliance_API.Models;

namespace migo_be.Models
{
    public class ProjectDto
    {

        public string Name { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;

        public string Deadline { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Employee>? AssignedEmployees { get; set; }
    }
}

