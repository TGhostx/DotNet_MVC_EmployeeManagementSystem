using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Common;
using EMS.Domain.Enums;

namespace EMS.Domain.Models
{
    [Table("LeaveRequests")]
    public class LeaveRequest: BaseModel
    {
        [Required]
        public DateTime StartDate { get; private set;}
        [Required]
        public DateTime EndDate { get; private set;}
        [Required]
        [MaxLength(250)]
        public string Reason { get; private set; } = string.Empty;
        [Required]
        public LeaveStatus Status { get; private set; } = LeaveStatus.Pending;
        
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;


        protected LeaveRequest() { }

        public LeaveRequest(DateTime startDate, DateTime endDate, string reason, int employeeId)
        {
            StartDate = startDate.Date;
            EndDate = endDate.Date;
            Reason = reason;
            EmployeeId = employeeId;
            Status = LeaveStatus.Pending;
        }

        public LeaveRequest(int employeeId, DateTime startDate, DateTime endDate)
        {
            EmployeeId = employeeId;
            StartDate = startDate;
            EndDate = endDate.Date;
        }

        public void Approve()
        {
            Status = LeaveStatus.Approved;
            MarkAsUpdated();
        }

        public void Reject()
        {
            Status = LeaveStatus.Rejected;
            MarkAsUpdated();
        }

        public void Cancel()
        {
            Status = LeaveStatus.Cancelled;
            MarkAsUpdated();
        }
    }
}