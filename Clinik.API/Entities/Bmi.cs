using System;

namespace Clinik.API.Entities
{
    public class Bmi
    {

        private float weight;
        private float height;

        public Bmi(float weight, float height)
        {
            this.weight = weight;
            this.height = height;
        }

        public void setWeight(float weight){
            this.weight = weight;
        }

        public float getWeight(){
            return this.weight;
        }

        public void setHeight(float height){
            this.height = height;
        }

        public float getHeight(){
            return this.height;
        }

        public float calculateBmi(){
            return (this.weight / (this.height * this.height));
        }
        
    }
}