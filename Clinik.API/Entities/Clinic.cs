using System;
using System.Collections.Generic;

namespace Clinik.API.Entities
{
    [Serializable]
    public class Clinic
    {
        
        public int clinicId {get; set;}
        public string clinicName {get; set;}
        public string clinicAddress {get; set;}
        public List<Patient> patients {get; set;}

        public Clinic(){}

        public Clinic(int clinicId, string clinicName, string clinicAddress)
        {
            this.clinicId = clinicId;
            this.clinicName = clinicName;
            this.clinicAddress = clinicAddress;
            this.patients = new List<Patient>();
        }

        public void setSinglePatient(Patient patient){
            if(patient == null){
                return;
            }
            if(this.patients == null){
                this.patients = new List<Patient>();
            }
            this.patients.Add(patient);
        }

        public Patient getPatientById(int patientId){
            return this.patients.Find(patient => patient.patientId == patientId) ?? null;
        }

    }
}