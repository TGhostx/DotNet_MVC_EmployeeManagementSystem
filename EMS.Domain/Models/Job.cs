using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Common;

namespace EMS.Domain.Models
{
    [Table("Jobs")]
    public class Job: BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; private set; } = string.Empty;
        [Required]
        public decimal BaseSalary { get; private set; }
        
        public ICollection<Employee> Employees { get; private set;} = new List<Employee>();


        protected Job() { }

        public Job(string title, decimal baseSalary)
        {
            Title = title;
            BaseSalary = baseSalary;
        }

        public void Update(string title, decimal baseSalary)
        {
            Title = title;
            BaseSalary = baseSalary;
            MarkAsUpdated();
        }
    }
}