using Clinik.API.Entities;
using Clinik.API.Repositories;
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
        private IClinicRepository clinicRepository;

        public ClinicController(ILogger<ClinicController> logger, IClinicRepository clinicRepository)
        {
            _logger = logger;
            this.clinicRepository = clinicRepository;
        }

        [HttpGet]
        public IActionResult GetAllClinics()
        {
            List<Clinic> clinics = clinicRepository.getAllClinics();
            if(clinics != null)
            {
                return Ok(clinics);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetClinicById([FromRoute] int id){
            Clinic clinic = this.clinicRepository.getClinicById(id);
            if(clinic != null){
                return Ok(clinic);
            }
            else{
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddClinic([FromBody] Clinic clinic){
            this.clinicRepository.addClinic(clinic);
            return Ok();
        }

    }
}