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
    public class SyllabusController : ControllerBase
    {
         private readonly SyllabusService _syllabusService;

        public SyllabusController(SyllabusService syllabusService) =>
        _syllabusService = syllabusService;

        [HttpGet]
        [Route("GetSyllabus")]
        public IActionResult GetSyllabus()
        {
            return Ok(_syllabusService.GetSyllabus());
        }

        [HttpGet]
        [Route("GetSyllabusByID")]
        public IActionResult GetSyllabusByID(string semesterType)
        {
            return Ok(_syllabusService.GetSyllabusByID(semesterType));
        }

        [HttpPost]
        [Route("CreateSyllabus")]
        public IActionResult PostSyllabus(Syllabus _syllabus)
        {
            string msg;
            msg = _syllabusService.CreateSyllabus(_syllabus);
            return Ok(msg);
        }
    }
}
