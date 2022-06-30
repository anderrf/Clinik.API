using System;

namespace Clinik.API.Entities
{
    [Serializable]
    public class Patient
    {

        public int patientId {get; set;}
        public DateTime patientBirthdate {get; set;}
        public string patientName {get; set;}
        public char patientSex {get; set;}
        public Bmi patientBmi {get; set;}

        public Patient(){}

        public Patient(int patientId, DateTime patientBirthdate, string patientName, char patientSex, float weight, float height)
        {
            this.patientId = patientId;
            this.patientBirthdate = patientBirthdate;
            this.patientName = patientName;
            this.patientSex = patientSex;
            this.patientBmi = new Bmi(weight, height);
        }

        public float calculateBmi(){
            return this.patientBmi.calculateBmi();
        }

    }
}