using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.DTOs.Attenance
{
    public class AttendanceDto
    {
        public DateTime Date { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}