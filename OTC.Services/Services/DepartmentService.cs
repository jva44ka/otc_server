using Microsoft.EntityFrameworkCore;
using OTC.Domain.Interfaces;
using OTC.Domain.Models;
using OTC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OTC.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IList<Department> GetDepartments()
        {
            return _departmentRepository.GetAll()
                .Include(d => d.Employees)
                .OrderBy(d => d.Name)
                .ToList();
        }
    }
}
