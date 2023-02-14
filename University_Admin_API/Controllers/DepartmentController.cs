using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interface.IServices;
using BusinessLogic.Services;
using BusinessLogic.Model.Models;

namespace University_Admin_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService) =>
        _departmentService = departmentService;

        [HttpGet]
        [Route("GetDepartment")]
        public IActionResult GetDepartment()
        {
            return Ok(_departmentService.GetDepartment());
        }

        [HttpPost]
        [Route("CreateDepartment")]
        public IActionResult PostDepartment(Department _Department)
        {
            string msg;
            msg = _departmentService.CreateDepartment(_Department);
            return Ok(msg);
        }
    }
}
