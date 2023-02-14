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
    public class AffiliatedCollegesController : ControllerBase
    {
        private readonly AffiliatedCollegesService _affiliatedCollegesService;

        public AffiliatedCollegesController(AffiliatedCollegesService affiliatedCollegesService) =>
        _affiliatedCollegesService = affiliatedCollegesService;

        [HttpGet]
        [Route("GetAffiliatedColleges")]
        public IActionResult GetAffiliatedColleges()
        {
            return Ok(_affiliatedCollegesService.GetAffiliatedColleges());
        }
    }
}
