using System.Collections.Generic;
using Clinik.API.Entities;

namespace Clinik.API.Repositories
{
    public interface IClinicRepository
    {
        
        public void AddClinic(Clinic clinic);

        public Clinic GetClinicById(int clinicId);

        public List<Clinic> GetAllClinics();

        public void UpdateClinicById(int clinicId, Clinic clinic);

        public void DeleteClinicById(int clinicId);

        public void AddPatient(int clinicId, Patient patient);

        public Patient GetPatientByClinicIdAndPatientId(int clinicId, int patientId);

        public List<Patient> GetAllPatientsByClinicId(int clinicId);

        public void UpdatePatientById(int clinicId, int patientId, Patient patient);

        public void DeletePatientById(int clinicId, int patientId);

    }
}