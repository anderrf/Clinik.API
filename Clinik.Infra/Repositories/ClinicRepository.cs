using System;
using System.Collections.Generic;
using System.Text;
using Clinik.Domain.Entities;

namespace Clinik.Infra.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private static List<Clinic> clinicList = new List<Clinic>();

        public void AddClinic(Clinic clinic)
        {
            if (clinic == null)
            {
                return;
            }
            clinicList.Add(clinic);
        }
        public Clinic GetClinicById(int clinicId)
        {
            return clinicList.Find(clinic => clinic.clinicId == clinicId);
        }

        public List<Clinic> GetAllClinics()
        {
            return clinicList ?? null;
        }

        public void UpdateClinicById(int clinicId, Clinic clinic)
        {
            int clinicIndex = clinicList.FindIndex(clinic => clinic.clinicId == clinicId);
            if (clinicIndex < 0)
            {
                return;
            }
            clinicList[clinicIndex] = clinic;
        }

        public void DeleteClinicById(int clinicId)
        {
            int clinicIndex = clinicList.FindIndex(clinic => clinic.clinicId == clinicId);
            if (clinicIndex < 0)
            {
                return;
            }
            clinicList.RemoveAt(clinicIndex);
        }

        public void AddPatient(int clinicId, Patient patient)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (clinicIndex < 0)
            {
                return;
            }
            clinicList[clinicIndex].SetSinglePatient(patient);
        }

        public Patient GetPatientByClinicIdAndPatientId(int clinicId, int patientId)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (GetClinicIndexByClinicId(clinicId) < 0)
            {
                return null;
            }
            return clinicList[clinicIndex].GetPatientById(patientId);
        }

        public List<Patient> GetAllPatientsByClinicId(int clinicId)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (GetClinicIndexByClinicId(clinicId) < 0)
            {
                return null;
            }
            return clinicList[clinicIndex].GetAllPatients();
        }

        public void UpdatePatientById(int clinicId, int patientId, Patient patient)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (GetClinicIndexByClinicId(clinicId) < 0)
            {
                return;
            }
            clinicList[clinicIndex].UpdatePatient(patientId, patient);
        }

        public void DeletePatientById(int clinicId, int patientId)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (GetClinicIndexByClinicId(clinicId) < 0)
            {
                return;
            }
            clinicList[clinicIndex].DeletePatientById(patientId);
        }

        private int GetClinicIndexByClinicId(int clinicId)
        {
            return clinicList.FindIndex(clinic => clinic.clinicId == clinicId);
        }

    }
}
