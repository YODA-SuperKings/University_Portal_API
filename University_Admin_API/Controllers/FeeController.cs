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
    public class FeeController : ControllerBase
    {
         private readonly FeeService _feeService;

        public FeeController(FeeService feeService) =>
        _feeService = feeService;

        [HttpGet]
        [Route("GetFee")]
        public IActionResult GetFee()
        {
            return Ok(_feeService.GetFee());
        }

        [HttpPost]
        [Route("CreateFee")]
        public IActionResult PostFee(Fee _fee)
        {
            string msg;
            msg = _feeService.CreateFee(_fee);
            return Ok(msg);
        }
    }
}
