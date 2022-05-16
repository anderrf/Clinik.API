using System.Collections.Generic;

namespace Clinik.API.Entities
{
    public class Clinic
    {
        
        private int clinicId;
        private string clinicName;
        private string clinicAddress;
        private List<Patient> patients;

        public Clinic(string clinicName, string clinicAddress)
        {
            this.clinicName = clinicName;
            this.clinicAddress = clinicAddress;
            this.patients = new List<Patient>();
        }

        public int getClinicId(){
            return this.clinicId;
        }
        
        public void setClinicName(string clinicName){
            this.clinicName = clinicName;
        }

        public string getClinicName(){
            return this.clinicName;
        }

        public void setClinicAddress(string clinicAddress){
            this.clinicAddress = clinicAddress;
        }

        public string getClinicAddress(){
            return this.clinicAddress;
        }

        public List<Patient> getAllPatients(){
            return this.patients;
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

    }
}