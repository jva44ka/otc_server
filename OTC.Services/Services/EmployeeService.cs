using OTC.Domain.Interfaces;
using OTC.Domain.Models;
using OTC.Services.Interfaces;
using System;

namespace OTC.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public Employee Create(Employee employee)
        {
            var existingEmployee = _employeeRepository.GetById(employee.Id);
            if (existingEmployee != null)
                throw new ArgumentException("Employee with same id already exists");

            var createdEmployee = _employeeRepository.Create(employee);
            _employeeRepository.SaveChanges();

            return createdEmployee;
        }

        public Employee Update(Guid id, Employee newEmployee)
        {
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee == null)
                throw new ArgumentException("Employee with that id not exists");

            existingEmployee.Name = newEmployee.Name ??= existingEmployee.Name;
            existingEmployee.Salary = newEmployee.Salary;
            existingEmployee.DepartmentId = newEmployee.DepartmentId;

            var updatedEmployee = _employeeRepository.Update(existingEmployee);
            _employeeRepository.SaveChanges();

            return updatedEmployee;
        }

        public Employee Delete(Guid id)
        {
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee == null)
                throw new ArgumentException("Employee with that id not exists");

            var removedEmployee = _employeeRepository.Delete(id);
            _employeeRepository.SaveChanges();

            return removedEmployee;
        }
    }
}
