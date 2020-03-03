using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson
{
    private int age;
    private string name;

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
