using System;
using System.Collections.Generic;
using System.Text;

public abstract class Food
{
    private int happinessPoints;

    public Food(int points)
    {
        this.HappinessPoints = points;
    }

    public int HappinessPoints
    {
        get { return happinessPoints; }
        private set { happinessPoints = value; }
    }
}
