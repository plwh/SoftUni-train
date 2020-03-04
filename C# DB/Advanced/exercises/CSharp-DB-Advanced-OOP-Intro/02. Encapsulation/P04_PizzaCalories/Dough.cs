using System;
using System.Collections.Generic;
using System.Text;

namespace P04_PizzaCalories
{
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");

                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                string technique = value.ToLower();
                if (technique != "crispy" && technique != "chewy" && technique != "homemade")
                    throw new ArgumentException("Invalid type of dough.");

                this.bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                string type = value.ToLower();
                if (type != "white" && type != "wholegrain")
                    throw new ArgumentException("Invalid type of dough."); 

                this.flourType = value;
            }
        }

        public double Calories
        {
            get
            {
                double result = BaseCaloriesPerGram * this.Weight;

                switch (this.FlourType.ToLower())
                {
                    case "white":
                        result *= 1.5;
                        break;
                    case "wholegrain":
                        result *= 1.0;
                        break;
                }

                switch (this.BakingTechnique.ToLower())
                {
                    case "crispy":
                        result *= 0.9;
                        break;
                    case "chewy":
                        result *= 1.1;
                        break;
                    case "homemade":
                        result *= 1.0;
                        break;
                }

                return result;
            }
        }
    }
}
