using Microsoft.AspNetCore.Mvc;
using OTC.Domain.Models;
using OTC.Services.Interfaces;
using System.Collections.Generic;

namespace OTC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IList<Department> GetDepartments()
        {
            return _departmentService.GetDepartments();
        }
    }
}
