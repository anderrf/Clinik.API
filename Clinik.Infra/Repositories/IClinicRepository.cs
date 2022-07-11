using System;
using System.Collections.Generic;
using System.Text;
using Clinik.Domain.Entities;

namespace Clinik.Infra.Repositories
{
    public interface IClinicRepository
    {

        public Clinic AddClinic(Clinic clinic);

        public Clinic GetClinicById(int clinicId);

        public List<Clinic> GetAllClinics();

        public Clinic UpdateClinicById(int clinicId, Clinic clinic);

        public bool DeleteClinicById(int clinicId);

        public Patient AddPatient(int clinicId, Patient patient);

        public Patient GetPatientByClinicIdAndPatientId(int clinicId, int patientId);

        public List<Patient> GetAllPatientsByClinicId(int clinicId);

        public Patient UpdatePatientById(int clinicId, int patientId, Patient patient);

        public bool DeletePatientById(int clinicId, int patientId);

    }
}
