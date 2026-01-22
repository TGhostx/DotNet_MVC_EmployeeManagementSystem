using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.DTOs.Employees
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public string Department { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
    }
}