using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}