using OTC.Domain.Models;
using System.Collections.Generic;

namespace OTC.Services.Interfaces
{
    public interface IDepartmentService
    {
        public IList<Department> GetDepartments();
    }
}
