using System;
using System.Collections.Generic;
using System.Text;

class StreetExtraordinaire : Cat
{
    private int decibelsOfMeows;

    public StreetExtraordinaire(string name, int decibelsOfMeows)
        : base(name)
    {
        this.DecibelsOfMeows = decibelsOfMeows;
    }

    public int DecibelsOfMeows
    {
        get { return decibelsOfMeows; }
        set { decibelsOfMeows = value; }
    }

    public override string ToString()
    {
        return "StreetExtraordinaire " + this.Name + " " + this.DecibelsOfMeows;
    }
}
