using System;
using System.Collections.Generic;
using System.Text;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private int weight;
    private const int BaseCaloriesPerGram = 2;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public string BakingTechnique
    {
        get { return bakingTechnique; }
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public string FlourType
    {
        get { return flourType; }
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
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
