using OTC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OTC.Domain.Models
{
    [Table("Departments")]
    public class Department : IDataModel
    {
        [Key, Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public decimal Salary 
        {
            get
            {
                if (this.Employees == null || this.Employees.Count == 0)
                    return 0;
                return this.Employees.Select(e => e.Salary).Average();
            }
        }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
