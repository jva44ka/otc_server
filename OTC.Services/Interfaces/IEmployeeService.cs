using OTC.Domain.Models;
using System;

namespace OTC.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Employee Create(Employee employee);
        public Employee Update(Guid id, Employee updatedEmployee);
        public Employee Delete(Guid id);
    }
}
