using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson, IBuyer
{
    private string name;
    private int age;
    private string id;
    private string birthdate;
    
    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
        this.Food = 0;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }

    public int Food { get; set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}
