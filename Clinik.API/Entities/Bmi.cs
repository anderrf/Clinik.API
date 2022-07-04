using System;

namespace Clinik.API.Entities
{
    [Serializable]
    public class Bmi
    {

        public float weight {get; set;}
        public float height {get; set;}

        public Bmi(){}

        public Bmi(float weight, float height)
        {
            this.weight = weight;
            this.height = height;
        }

        public float CalculateBmi()
        {
            return (this.weight / (this.height * this.height));
        }
        
    }
}