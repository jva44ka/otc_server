using OTC.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTC.Domain.Models
{
    [Table("Employees")]
    public class Employee : IDataModel
    {
        [Key, Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey(nameof(Department))]
        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
