using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Gandalf
{
    private List<Food> foods;
    private Mood mood;

    public Gandalf(List<Food> eatenFood)
    {
        this.Foods = eatenFood;
        this.Mood = MoodFactory.GetMood(this.Foods);
    }

    public Mood Mood
    {
        get { return mood; }
        private set { mood = value; }
    }

    public List<Food> Foods
    {
        get { return foods; }
        private set { foods = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat($@"{this.Foods.Sum(a => a.HappinessPoints)}
{this.Mood.Description}");

        return sb.ToString();
    }
}
