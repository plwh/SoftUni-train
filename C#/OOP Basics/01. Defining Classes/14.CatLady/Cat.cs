using System;
using System.Collections.Generic;
using System.Text;

class Cat
{
    private string name;

    public Cat(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
