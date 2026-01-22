using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.DTOs.Job
{
    public class CreateJobDto
    {
        [Required]
        public string Title { get; set; } = null!;

        [Range(0, double.MaxValue)]
        public decimal BaseSalary { get; set; }
    }
}