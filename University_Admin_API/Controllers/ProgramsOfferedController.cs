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
    public class ProgramsOfferedController : ControllerBase
    {
         private readonly ProgramsOfferedService _programsOfferedService;

        public ProgramsOfferedController(ProgramsOfferedService programsOfferedService) =>
        _programsOfferedService = programsOfferedService;

        [HttpGet]
        [Route("GetProgramsOffered")]
        public IActionResult GetProgramsOffered()
        {
            return Ok(_programsOfferedService.GetProgramsOffered());
        }

        [HttpPost]
        [Route("CreateProgramsOffered")]
        public IActionResult PostProgramsOffered(ProgramsOffered _programsOffered)
        {
            string msg;
            msg = _programsOfferedService.CreateProgramsOffered(_programsOffered);
            return Ok(msg);
        }
    }
}
