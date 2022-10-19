using Alliance_API.Models;
using System.Text.Json.Serialization;

namespace migo_be.Models
{
    public class EmployeeTimeLogs
    {
        public int Id { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }

        public DateTime Time { get; set; }

        public string Action { get; set; } = string.Empty;

        public string Remark { get; set; } = string.Empty;
    }
}
