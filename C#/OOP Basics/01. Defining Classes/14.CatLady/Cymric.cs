using System;
using System.Collections.Generic;
using System.Text;

class Cymric : Cat
{
    private double furLength;

    public Cymric(string name, double furLength)
        : base(name)
    {
        this.FurLength = furLength;
    }

    public double FurLength
    {
        get { return furLength; }
        set { furLength = value; }
    }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:f2}";
    }
}
