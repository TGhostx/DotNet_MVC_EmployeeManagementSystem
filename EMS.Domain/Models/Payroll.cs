using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Common;

namespace EMS.Domain.Models
{
    [Table("Payrolls")]
    public class Payroll: BaseModel
    {
        // Payroll Period
        [Range(1, 12)]
        public int Month { get; private set; }
        [Range(2000, 2100)]
        public int Year { get; private set; }
        
        // Financial Data
        [Required]
        public decimal BaseSalary { get; private set; }
        public decimal Allowances { get; private set; }
        public decimal Deductions { get; private set; }
        [Required]
        public decimal NetSalary { get; private set; }
        
        // Payment Info
        public bool IsPaid { get; private set; }
        public DateTime? PaidAt { get; private set; }

        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;


        protected Payroll() { }

        public Payroll(int month, int year, decimal baseSalary, decimal allowances, decimal deductions, int employeeId)
        {
            Month = month;
            Year = year;
            BaseSalary = baseSalary;
            Allowances = allowances;
            Deductions = deductions;
            EmployeeId = employeeId;
            
            RecalculateNetSalary();
            IsPaid = false;
        }

        public Payroll(int employeeId, int month, int year, decimal baseSalary)
        {
            EmployeeId = employeeId;
            Month = month;
            Year = year;
            BaseSalary = baseSalary;
        }

        public void UpdateAllowances(decimal amount)
        {
            Allowances = amount;
            RecalculateNetSalary();
            MarkAsUpdated();
        }

        public void UpdateDeductions(decimal amount)
        {
            Deductions = amount;
            RecalculateNetSalary();
            MarkAsUpdated();
        }

        public void MarkAsPaid()
        {
            if (IsPaid)
                throw new InvalidOperationException("Payroll is already paid.");

            IsPaid = true;
            PaidAt = DateTime.UtcNow;
            MarkAsUpdated();
        }

        private void RecalculateNetSalary()
        {
            NetSalary = BaseSalary + Allowances - Deductions;
        }
    }
}