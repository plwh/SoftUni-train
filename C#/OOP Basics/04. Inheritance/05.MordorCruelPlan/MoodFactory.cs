using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MoodFactory
{
    internal static Mood GetMood(List<Food> foods)
    {
        int happinessPoints = foods.Sum(a => a.HappinessPoints);

        if (happinessPoints < -5)
        {
            return new Mood("Angry");
        }
        if (happinessPoints >= -5 && happinessPoints <= 0)
        {
            return new Mood("Sad");
        }
        if (happinessPoints >= 1 && happinessPoints <= 15)
        {
            return new Mood("Happy");
        }

        return new Mood("JavaScript");
    }
}
