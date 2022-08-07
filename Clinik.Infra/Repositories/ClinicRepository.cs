using System;
using System.Collections.Generic;
using System.Text;
using Clinik.Domain.Entities;

namespace Clinik.Infra.Repositories
{
    public class ClinicRepository : IClinicRepository
    {
        private static List<Clinic> clinicList = new List<Clinic>();
        private static int clinicIndex = 0;
        private static int patientIndex = 0;

        public Clinic AddClinic(Clinic clinic)
        {
            if (clinic == null)
            {
                return null;
            }
            clinic._id = ++clinicIndex;
            clinicList.Add(clinic);
            return clinicList[clinicList.Count - 1];
        }
        public Clinic GetClinicById(int clinicId)
        {
            return clinicList.Find(clinic => clinic._id == clinicId) ?? null;
        }

        public List<Clinic> GetAllClinics()
        {
            return clinicList ?? null;
        }

        public Clinic UpdateClinicById(int clinicId, Clinic clinic)
        {
            int clinicIndex = this.GetClinicIndexByClinicId(clinicId);
            if (clinicIndex < 0)
            {
                return null;
            }
            clinic._id = clinicId;
            clinicList[clinicIndex] = clinic;
            return clinicList[clinicIndex];
        }

        public bool DeleteClinicById(int clinicId)
        {
            int clinicIndex = clinicList.FindIndex(clinic => clinic._id == clinicId);
            if (clinicIndex < 0)
            {
                return false;
            }
            clinicList.RemoveAt(clinicIndex);
            return this.GetClinicById(clinicId) == null ? true : false;

        }

        public Patient AddPatient(int clinicId, Patient patient)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (clinicIndex < 0)
            {
                return null;
            }
            patient._id = ++patientIndex;
            clinicList[clinicIndex].SetSinglePatient(patient);
            return clinicList[clinicIndex].GetPatientById((int)patient._id);
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

        public Patient UpdatePatientById(int clinicId, int patientId, Patient patient)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (GetClinicIndexByClinicId(clinicId) < 0)
            {
                return null;
            }
            patient._id = patientId;
            clinicList[clinicIndex].UpdatePatient(patientId, patient);
            return clinicList[clinicIndex].GetPatientById(patientId);
        }

        public bool DeletePatientById(int clinicId, int patientId)
        {
            int clinicIndex = GetClinicIndexByClinicId(clinicId);
            if (GetClinicIndexByClinicId(clinicId) < 0)
            {
                return false;
            }
            clinicList[clinicIndex].DeletePatientById(patientId);
            return clinicList[clinicIndex].GetPatientById(patientId) == null ? true : false;
        }

        private int GetClinicIndexByClinicId(int clinicId)
        {
            return clinicList.FindIndex(clinic => clinic._id == clinicId);
        }

    }
}
