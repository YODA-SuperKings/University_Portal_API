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
    public class StaffController : ControllerBase
    {
         private readonly StaffService _staffService;

        public StaffController(StaffService staffService) =>
        _staffService = staffService;

        [HttpGet]
        [Route("GetStaff")]
        public IActionResult GetStaff()
        {
            return Ok(_staffService.GetStaff());
        }

        [HttpPost]
        [Route("CreateStaff")]
        public IActionResult PostStaff(Staff _staff)
        {
            string msg;
            msg = _staffService.CreateStaff(_staff);
            return Ok(msg);
        }
    }
}
