using Microsoft.AspNetCore.Mvc;
using OTC.Domain.Models;
using OTC.Services.Interfaces;
using System;

namespace OTC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            return _employeeService.Create(value);
        }

        [HttpPut("{id}")]
        public Employee Put(Guid id, [FromBody] Employee value)
        {
            if (id != value.Id)
                throw new ArgumentException("Id should not change");

            return _employeeService.Update(id, value);
        }

        [HttpDelete("{id}")]
        public Employee Delete(Guid id)
        {
            return _employeeService.Delete(id);
        }
    }
}
