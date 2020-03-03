using System;
using System.Collections.Generic;
using System.Text;

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    private int age;
    private string name;
    private string id;
    private string birthDate;

    public Citizen(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthDate;
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

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Birthdate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }
}
