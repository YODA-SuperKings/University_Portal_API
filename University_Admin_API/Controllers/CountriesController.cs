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
    public class CountriesController : ControllerBase
    {
        private readonly CountriesService _countriesService;

        public CountriesController(CountriesService countriesService) =>
        _countriesService = countriesService;

        [HttpGet]
        [Route("GetCountries")]
        public IActionResult GetUsers()
        {
            return Ok(_countriesService.GetCountries());
        }
    }
}
