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
    [Table("Attendances")]
    public class Attendance: BaseModel
    {
        [Required]
        public DateTime Date { get; private set;}
        public AttendanceStatus Status { get; private set;}
        
        public int EmployeeId { get; private set;}
        public Employee Employee { get; private set;} = null!;


        protected Attendance() { }

        public Attendance(DateTime date, AttendanceStatus status, int employeeId)
        {
            Date = date.Date;
            Status = status;
            EmployeeId = employeeId;
        }

        public Attendance(int employeeId, DateTime date)
        {
            EmployeeId = employeeId;
            Date = date;
            Status = AttendanceStatus.Present;
            MarkAsCreated();
        }

        public void UpdateStatus(AttendanceStatus status)
        {
            Status = status;
            MarkAsUpdated();
        }
    }
}