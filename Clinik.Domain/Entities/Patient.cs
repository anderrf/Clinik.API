using System;
using System.Collections.Generic;
using System.Text;

namespace Clinik.Domain.Entities
{
    [Serializable]
    public class Patient
    {

        public int? _id { get; set; }
        public DateTime patientBirthdate { get; set; }
        public string patientName { get; set; }
        public char patientSex { get; set; }
        public Bmi patientBmi { get; set; }

        public Patient() { }

        public Patient(int patientId, DateTime patientBirthdate, string patientName, char patientSex, float weight, float height)
        {
            this._id = patientId;
            this.patientBirthdate = patientBirthdate;
            this.patientName = patientName;
            this.patientSex = patientSex;
            this.patientBmi = new Bmi(weight, height);
        }

        public float CalculateBmi()
        {
            return this.patientBmi.CalculateBmi();
        }

    }
}
