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
    [Table("Employees")]
    public class Employee: BaseModel
    {
        // Personal Information
        [Required]
        [MaxLength(30)]
        public string FirstName { get; private set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string LastName { get; private   set; } = string.Empty;
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; private set; } = string.Empty;
        [Phone]
        [MaxLength(15)]
        public string? PhoneNumber { get; private set; }

        [Required]
        public DateTime DateOfBirth { get; private set; }

        // Employment Information
        [Required]
        public DateTime HireDate { get; private set; }
        [Required]
        public EmployeeStatus Status { get; private set; } = EmployeeStatus.Active;

        // Identity reference
        public string? UserId { get; private set; } // For future 
        
        // Navigation Properties
        // [ForeignKey(nameof(Department))]
        public int DepartmentId { get; private set; }
        public int JobId { get; private set; }

        public ICollection<Attendance> Attendances { get; private set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; private set; } = new List<LeaveRequest>();
        public ICollection<Payroll> Payrolls { get; private set; } = new List<Payroll>();


        protected Employee() { }

        public Employee(string firstName, string lastName, string email, DateTime dateOfBirth, DateTime hireDate, int departmentId, int jobId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            HireDate = hireDate;
            DepartmentId = departmentId;
            JobId = jobId;
            Status = EmployeeStatus.Active;
        }

        public void ChangeDepartmant(int departmentId)
        {
            DepartmentId = departmentId;
            MarkAsUpdated();
        }

        public void ChangeJob(int jobId)
        {
            JobId = jobId;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            Status = EmployeeStatus.Inactive;
            MarkAsUpdated();
        }

        public void Activate()
        {
            Status = EmployeeStatus.Active;
            MarkAsUpdated();
        }

        public void Terminated()
        {
            Status = EmployeeStatus.Terminated;
            MarkAsUpdated();
        }

        public void OnLeave()
        {
            Status = EmployeeStatus.OnLeave;
            MarkAsUpdated();
        }

        public void AssignUser(string userId)
        {
            UserId = userId;
            MarkAsUpdated();
        }
    }
}