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
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;
        private readonly StudentService _studentService;
        private readonly ProgramsOfferedService _programsOfferedService;
        private readonly PaymentService _paymentService;
        private readonly FeeService _feeService;

        public UsersController(UsersService userService, StudentService studentService, ProgramsOfferedService programsOfferedService, PaymentService paymentService, FeeService feeService)
        {
            _userService = userService;
            _studentService = studentService;
            _programsOfferedService = programsOfferedService;
            _paymentService = paymentService;
            _feeService = feeService;
        }

        [HttpGet]
        [Route("AuthenticateUser")]
        public async Task<IActionResult> AuthenticateUser(string username, string password)
        {
            int loginType = 0;
            var user = _userService.GetUsers();
            if (user.Any() && (username != null || username != string.Empty) && (password != null || password != string.Empty))
            {
                loginType = user.Where(u => u.UserName == username && u.Password == password).Select(u => u.LoginType).FirstOrDefault();
            }
            return Ok(loginType);
        }

        [HttpGet]
        [Route("GetStudentByUserID")]
        public IActionResult GetStudentByUserID(string registrationNo)
        {
            Student _student = new Student();
            var studentInfo = _studentService.GetStudent();
            var fee = _feeService.GetFee().Sum(_fee => _fee.Amount);
            var payment = _paymentService.GetPayment().Where(p => p.RegistrationNo == registrationNo).Sum(p => p.Amount);
            bool paymentStatus = false;

            if (fee <= payment)
            {
                paymentStatus = true;
            }

            if (studentInfo.Any() && (registrationNo != null || registrationNo != string.Empty))
            {
                _student = studentInfo.Where(u => u.RegistrationNo == registrationNo).FirstOrDefault();


                if (_student?.CourseAppliedType != null)
                {
                    _student.CourseAppliedType = _programsOfferedService.GetProgramsOffered().Where(p => p.slno == _student.CourseAppliedType).FirstOrDefault().CourseName;
                }

                if (_student != null)
                {
                    var _studentInfo = new
                    {
                        FirstName = _student.FirstName,
                        LastName = _student.LastName,
                        GraduatedYear = _student.GraduatedYear,
                        CourseAppliedType = _student?.CourseAppliedType,
                        PaymentStatus = paymentStatus
                    };

                    return Ok(_studentInfo);
                }

            }
            return Ok(_student);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult PostUser(Users newUser)
        {
            string msg;
            msg = _userService.CreateUser(newUser);
            return Ok(msg);
        }
    }
}
