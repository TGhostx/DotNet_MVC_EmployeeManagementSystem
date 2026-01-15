using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Common;

namespace EMS.Domain.Models
{
    [Table("Departments")]
    public class Department: BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; } = string.Empty;
        [MaxLength(250)]
        public string? Location { get; private set; }
        
        public ICollection<Employee> Employees { get; private set; } = new List<Employee>();

        protected Department() { }

        public Department(string name, string? location = null)
        {
            Name = name;
            Location = location;
        }

        public void Update(string name, string? location = null)
        {
            Name = name;
            Location = location;
            MarkAsUpdated();
        }
    }
}