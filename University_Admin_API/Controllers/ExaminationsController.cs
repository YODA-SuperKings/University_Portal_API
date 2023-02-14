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
    public class ExaminationsController : ControllerBase
    {
         private readonly ExaminationsService _examinationsService;
         private readonly SyllabusService _syllabusService;
         private readonly StudentService _studentService;
        public ExaminationsController(ExaminationsService examinationsService, SyllabusService syllabusService, StudentService studentService)
        {
            _examinationsService = examinationsService;
            _syllabusService = syllabusService;
            _studentService = studentService;
        }
        [HttpGet]
        [Route("GetExaminations")]
        public IActionResult GetExaminations()
        {
            return Ok(_examinationsService.GetExaminations());
        }

        [HttpGet]
        [Route("GetExaminationsBySemesterID")]
        public IActionResult GetExaminationsBySemesterID(string semesterType)
        {
            var syllabus = _syllabusService.GetSyllabusByID(semesterType).ToList();

            var studentInfos = _studentService.GetStudent().ToList();

            var examinations = _examinationsService.GetExaminations().ToList();

            var result = from sys in syllabus
                         join s in studentInfos on sys.ProgramId equals s.CourseAppliedType
                         orderby s.RegistrationNo
                         select new {
                             RegistrationNo = s.RegistrationNo,
                             StudentName = s.FirstName +" " + s.LastName,
                             DOB =s.DateofBirth,
                             CourseCode = sys.CourseCode,
                             CourseName = sys.CourseTitle,
                             Mark = "",
                             IsPublishedResults = "Not Published"
                         };


            if (examinations.Count > 0)
            {
                var result1 = from sys in syllabus
                             join ex in examinations on sys.CourseCode equals ex.CourseCode
                             join s in studentInfos on sys.ProgramId equals s.CourseAppliedType
                             orderby s.RegistrationNo
                             select new
                             {
                                 RegistrationNo = s.RegistrationNo,
                                 StudentName = s.FirstName + " " + s.LastName,
                                 DOB = s.DateofBirth,
                                 CourseCode = ex.CourseCode,
                                 CourseName = sys.CourseTitle,
                                 Mark = ex.Mark,
                                 IsPublishedResults = ex.IsPublishedResults
                             };

                return Ok(result1);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetExaminationsByRegistrationID")]
        public IActionResult GetExaminationsByRegistrationID(string registrationNo, string semesterType)
        {
            var syllabus = _syllabusService.GetSyllabus().Where(syl=>syl.SemesterType == semesterType).ToList();

            var studentInfos = _studentService.GetStudent().Where(s => s.RegistrationNo == registrationNo).ToList();

            var examinations = _examinationsService.GetExaminations().ToList();

            var result = from sys in syllabus
                          join ex in examinations on sys.CourseCode equals ex.CourseCode
                          join s in studentInfos on sys.ProgramId equals s.CourseAppliedType
                          orderby s.RegistrationNo
                          select new {
                                  RegistrationNo = s.RegistrationNo,
                                  StudentName = s.FirstName + " " + s.LastName,
                                  DOB = s.DateofBirth,
                                  CourseCode = ex.CourseCode,
                                  CourseName = sys.CourseTitle,
                                  Mark = ex.Mark,
                                  IsPublishedResults = ex.IsPublishedResults
                              };
              
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateExaminations")]
        public IActionResult PostExaminations(Examinations _examinations)
        {
            string msg;
            msg = _examinationsService.CreateExaminations(_examinations);
            return Ok(msg);
        }

        [HttpPost]
        [Route("UpdateExaminations")]
        public IActionResult Update()
        {
            _examinationsService.Update();

            return Ok("Exam results published");
        }
    }
}
