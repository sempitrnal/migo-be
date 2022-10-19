
using System.Text.Json.Serialization;
using Alliance_API.Models;

namespace migo_be.Models
{
    public class EmployeeTimeLogDto
    {
        [JsonIgnore]
        public Employee? Employee { get; set; }
        [JsonIgnore]
        public int EmployeeId { get; set; }

        public DateTime Time { get; set; }

        public string Action { get; set; } = string.Empty;

        public string Remark { get; set; } = string.Empty;
    }
}

