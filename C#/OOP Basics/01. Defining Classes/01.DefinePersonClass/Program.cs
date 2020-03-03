using System;

public class Program
{
    static void Main()
    {
        Person person1 = new Person("John",50);
        //inline initialization
        Person person2 = new Person
        {
            Name = "Hristo",
            Age = 26
        };
    }
}