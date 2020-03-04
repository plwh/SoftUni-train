using System;
using System.Collections.Generic;
using System.Text;

namespace P04_PizzaCalories
{
    public class Topping
    {
        private const int BaseCaloriesPerGram = 2;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");

                this.weight = value;
            }
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                string type = value.ToLower();
                if (type != "meat" && type != "veggies" && type != "cheese" && type != "sauce")
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");

                this.type = value;
            }
        }

        public double Calories
        {
            get
            {
                double result = BaseCaloriesPerGram * this.Weight;

                switch (this.Type.ToLower())
                {
                    case "meat":
                        result *= 1.2;
                        break;
                    case "veggies":
                        result *= 0.8;
                        break;
                    case "cheese":
                        result *= 1.1;
                        break;
                    case "sauce":
                        result *= 0.9;
                        break;
                }

                return result;
            }
        }
    }
}
