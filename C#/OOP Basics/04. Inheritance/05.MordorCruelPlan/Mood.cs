using System;
using System.Collections.Generic;
using System.Text;

public class Mood
{
    private string description;

    public Mood(string desc)
    {
        this.Description = desc;
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }
}
