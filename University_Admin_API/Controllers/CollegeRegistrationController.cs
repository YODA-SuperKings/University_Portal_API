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
    public class CollegeRegistrationController : ControllerBase
    {
         private readonly CollegeRegistrationService _collegeRegistrationService;

        public CollegeRegistrationController(CollegeRegistrationService collegeRegistrationService) =>
        _collegeRegistrationService = collegeRegistrationService;

        [HttpGet]
        [Route("GetCollegeRegistration")]
        public IActionResult GetCollegeRegistration()
        {
            return Ok(_collegeRegistrationService.GetCollegeRegistration());
        }

        [HttpPost]
        [Route("CreateCollegeRegistration")]
        public IActionResult PostCollegeRegistration(CollegeRegistration _collegeRegistration)
        {
            string msg = "";
            if (_collegeRegistration != null)
            {
                msg = _collegeRegistrationService.CreateCollegeRegistration(_collegeRegistration);
            }
            return Ok(msg);
        }

        [HttpPost]
        [Route("UpdateCollegeRegistration")]
        public IActionResult Update(string id, string code)
        {
            var collegeRegistration = _collegeRegistrationService.GetCollegeRegistration(id, code).FirstOrDefault();

            if (collegeRegistration is null)
            {
                return NotFound();
            }

            collegeRegistration.IsActive = true;
            _collegeRegistrationService.Update(id, code, collegeRegistration);

            return Ok("College registration updated successfully");
        }
    }
}
