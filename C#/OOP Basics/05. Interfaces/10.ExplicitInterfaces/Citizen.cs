﻿using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IResident, IPerson
{
    public Citizen(string name, string country, int age)
    {
        this.Name = name;
        this.Country = country;
        this.Age = age;
    }

    public string Name { get; private set; }
    public string Country { get; private set; }
    public int Age { get; private set; }

    void IResident.GetName()
    {
        Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
    }

    void IPerson.GetName()
    {
        Console.WriteLine(this.Name);
    }
}
