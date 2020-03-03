using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Family
{
    private List<Person> people;

    public Family()
    {
        this.People = new List<Person>();
    }

    public List<Person> People
    {
        get { return people; }
        set { people = value; }
    }

    public void AddMember(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.People.OrderByDescending(p => p.Age).First();
    }
}

