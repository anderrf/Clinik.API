using System;

namespace Clinik.API.Entities
{
    public class Patient
    {

        private int patientId;
        private DateTime patientBirthdate;
        private string patientName;
        private char patientSex;
        private Bmi patientBmi;

        public Patient(DateTime patientBirthdate, string patientName, char patientSex, float weight, float height)
        {
            this.patientBirthdate = patientBirthdate;
            this.patientName = patientName;
            this.patientSex = patientSex;
            this.patientBmi = new Bmi(weight, height);
        }

        public int getPatientId(){
            return this.patientId;
        }

        public void setPatientBirthdate(DateTime patientBirthdate){
            this.patientBirthdate = patientBirthdate;
        }

        public DateTime getPatientBirthdate(){
            return this.patientBirthdate;
        }

        public void setPatientName(string patientName){
            this.patientName = patientName;
        }

        public string getPatientName(){
            return this.patientName;
        }

        public void setPatientSex(char patientSex){
            this.patientSex = patientSex;
        }

        public char getPatientSex(){
            return this.patientSex;
        }

        public void setWeight(float weight){
            this.patientBmi.setWeight(weight);
        }

        public float getWeight(){
            return this.patientBmi.getWeight();
        }

        public void setHeight(float height){
            this.patientBmi.setHeight(height);
        }

        public float getHeight(){
            return this.patientBmi.getHeight();
        }

    }
}