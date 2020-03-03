using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson
{
    private string name;
    private int age;
    private string id;

    public Citizen(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
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
}
