using Clinik.Domain.Entities;
using Clinik.Infra.Repositories;
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

        [HttpGet("/Clinics")]
        public IActionResult GetAllClinics()
        {
            List<Clinic> clinics = clinicRepository.GetAllClinics();
            if(clinics != null)
            {
                return Ok(clinics);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult AddClinic([FromBody] Clinic clinic)
        {
            Clinic newClinic = this.clinicRepository.AddClinic(clinic);
            if(newClinic == null)
            {
                return NotFound();
            }
            clinic.clinicId = newClinic.clinicId;
            if(!clinic.Equals(newClinic))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("{clinicId}")]
        public IActionResult GetClinicById([FromRoute] int clinicId)
        {
            Clinic clinic = this.clinicRepository.GetClinicById(clinicId);
            if(clinic == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(clinic);
            }
        }

        [HttpPut("{clinicId}")]
        public IActionResult UpdateClinicById([FromRoute] int clinicId, [FromBody] Clinic clinic)
        {
            Clinic searchedClinic = this.clinicRepository.GetClinicById(clinicId);
            if(searchedClinic == null)
            {
                return NotFound();
            }
            else
            {
                Clinic updatedClinic = this.clinicRepository.UpdateClinicById(clinicId, clinic);
                if(updatedClinic == null)
                {
                    return NotFound();
                }
                return Ok();
            }
        }

        [HttpDelete("{clinicId}")]
        public IActionResult DeleteClinicById([FromRoute] int clinicId)
        {
            Clinic searchedClinic = this.clinicRepository.GetClinicById(clinicId);
            if(searchedClinic == null)
            {
                return NotFound();
            }
            else
            {
                if(!this.clinicRepository.DeleteClinicById(clinicId))
                {
                    return NotFound();
                }
                return Ok();
            }
        }

        [HttpPost("{clinicId}/Patient")]
        public IActionResult AddPatient([FromRoute] int clinicId, [FromBody] Patient patient)
        {
            if(this.clinicRepository.GetClinicById(clinicId) == null)
            {
                return NotFound();
            }
            Patient newPatient = this.clinicRepository.AddPatient(clinicId, patient);
            patient.patientId = newPatient.patientId;
            if(!patient.Equals(newPatient))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("{clinicId}/Patient/{patientId}")]
        public IActionResult GetPatientById([FromRoute] int clinicId, [FromRoute] int patientId)
        {
            Patient patient = this.clinicRepository.GetPatientByClinicIdAndPatientId(clinicId, patientId);
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpGet("{clinicId}/Patients")]
        public IActionResult GetAllPatientsByClinicId([FromRoute] int clinicId)
        {
            List<Patient> patients = clinicRepository.GetAllPatientsByClinicId(clinicId);
            if(patients == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(patients);
            }
        }

        [HttpPut("{clinicId}/Patient/{patientId}")]
        public IActionResult UpdatePatient([FromRoute] int clinicId, [FromRoute] int patientId, [FromBody] Patient patient)
        {
            Patient searchedPatient = this.clinicRepository.GetPatientByClinicIdAndPatientId(clinicId, patientId);
            if(searchedPatient == null)
            {
                return NotFound();
            }
            Patient updatedPatient = this.clinicRepository.UpdatePatientById(clinicId, patientId, patient);
            return Ok();
        }

        [HttpDelete("{clinicId}/Patient/{patientId}")]
        public IActionResult DeletePatient([FromRoute] int clinicId, [FromRoute] int patientId)
        {
            Patient searchedPatient = this.clinicRepository.GetPatientByClinicIdAndPatientId(clinicId, patientId);
            if(searchedPatient == null)
            {
                return NotFound();
            }
            if(!this.clinicRepository.DeletePatientById(clinicId, patientId))
            {
                return NotFound();
            }
            return Ok();
        }

    }
}