using Clinik.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinik.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicController : ControllerBase
    {

        private readonly ILogger<ClinicController> _logger;

        public ClinicController(ILogger<ClinicController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Clinic Get()
        {
            return new Clinic("Blue Plain", "1st avenue, 184");
        }
    }
}