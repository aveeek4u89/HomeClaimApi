using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeClaimAPI.Service;
using HomeClaimAPI.Models;
using HomeClaimAPI.Exceptions;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeClaimAPI.Controllers
{
    //[ExceptionHandler]
    //[LoggingAspect]
    [Route("api/[controller]")]
    public class HomeClaimController : Controller
    {
        private readonly IHomeClaimService service;

        public HomeClaimController(IHomeClaimService _service)
        {
            this.service = _service;
        }
        
        // POST api/<controller>
       [HttpPost]
        public IActionResult Post([FromBody]HomeClaim homeClaim)
        {
            return Created("", service.CreateHomeClaim(homeClaim));
        }

        
    }
}
