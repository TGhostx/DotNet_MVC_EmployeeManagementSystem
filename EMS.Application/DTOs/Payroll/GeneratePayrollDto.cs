using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.DTOs.Payroll
{
    public class GeneratePayrollDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Range(1, 12)]
        public int Month { get; set; }

        public int Year { get; set; }
    }
}