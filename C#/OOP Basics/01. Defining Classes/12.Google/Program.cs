using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string inputLine = "";
            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] tokens = inputLine.Split();

                string personName = tokens[0];

                Person currentPerson = (people.Any(a => a.Name == personName) ? people.Find(a => a.Name == personName) : new Person(personName));

                if (tokens[1] == "company")
                {
                    string companyName = tokens[2];
                    string companyDepartment = tokens[3];
                    double companySalary = double.Parse(tokens[4]);

                    currentPerson.Company = new Company(companyName, companyDepartment, companySalary);
                }
                else if (tokens[1] == "pokemon")
                {
                    string pokemonName = tokens[2];
                    string pokemonType = tokens[3];

                    currentPerson.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                }
                else if (tokens[1] == "parents")
                {
                    string parentName = tokens[2];
                    string parentBirthday = tokens[3];

                    currentPerson.Parents.Add(new Parent(parentName, parentBirthday));

                }
                else if (tokens[1] == "children")
                {
                    string childName = tokens[2];
                    string childBirthday = tokens[3];

                    currentPerson.Children.Add(new Child(childName, childBirthday));
                }
                else if (tokens[1] == "car")
                {
                    string carModel = tokens[2];
                    int carSpeed = int.Parse(tokens[3]);

                    currentPerson.Car = new Car(carModel, carSpeed);
                }

                if (!people.Any(a => a.Name == currentPerson.Name))
                    people.Add(currentPerson);
            }

            string input = Console.ReadLine();
            Person personToPrint = people.Find(a => a.Name == input);

            Console.WriteLine(personToPrint.Name);
            Console.WriteLine("Company:");
            if (personToPrint.Company.Name != null)
                Console.WriteLine($"{personToPrint.Company.Name} {personToPrint.Company.Department} {personToPrint.Company.Salary:f2}");
            Console.WriteLine("Car:");
            if (personToPrint.Car.Model != null)
                Console.WriteLine($"{personToPrint.Car.Model} {personToPrint.Car.Speed}");
            Console.WriteLine("Pokemon:");
            personToPrint.Pokemons
                .Where(a => a.Name != null)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name} {a.Type}"));
            Console.WriteLine("Parents:");
            personToPrint.Parents
                .Where(a => a.Name != null)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name} {a.Birthday}"));
            Console.WriteLine("Children:");
            personToPrint.Children
                .Where(a => a.Name != null)
                .ToList()
                .ForEach(a => Console.WriteLine($"{a.Name} {a.Birthday}"));
        }

        class Person
        {
            private string name;
            private Company company;
            private Car car;
            private List<Parent> parents;
            private List<Child> children;
            private List<Pokemon> pokemons;

            public Person(string name)
            {
                this.Name = name;
                this.Company = new Company();
                this.Car = new Car();
                this.Parents = new List<Parent>();
                this.Children = new List<Child>();
                this.Pokemons = new List<Pokemon>();
            }

            public List<Pokemon> Pokemons
            {
                get { return pokemons; }
                set { pokemons = value; }
            }

            public List<Child> Children
            {
                get { return children; }
                set { children = value; }
            }

            public List<Parent> Parents
            {
                get { return parents; }
                set { parents = value; }
            }

            public Car Car
            {
                get { return car; }
                set { car = value; }
            }

            public Company Company
            {
                get { return company; }
                set { company = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        class Company
        {
            private string name;
            private string department;
            private double salary;

            public Company() { }

            public Company(string name, string department, double salary)
            {
                this.Name = name;
                this.Department = department;
                this.Salary = salary;
            }
            public double Salary
            {
                get { return salary; }
                set { salary = value; }
            }

            public string Department
            {
                get { return department; }
                set { department = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
        }

        class Pokemon
        {
            private string name;
            private string type;

            public Pokemon(string name, string type)
            {
                this.Name = name;
                this.Type = type;
            }

            public string Type
            {
                get { return type; }
                set { type = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public override string ToString()
            {
                return this.Name + " " + this.Type;
            }
        }

        class Parent
        {
            private string name;
            private string birthday;

            public Parent(string name, string birthday)
            {
                this.Name = name;
                this.Birthday = birthday;
            }

            public string Birthday
            {
                get { return birthday; }
                set { birthday = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public override string ToString()
            {
                return this.Name + " " + this.Birthday;
            }
        }

        class Child
        {
            private string name;
            private string birthday;

            public Child(string name, string birthday)
            {
                this.Name = name;
                this.Birthday = birthday;
            }

            public string Birthday
            {
                get { return birthday; }
                set { birthday = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public override string ToString()
            {
                return this.Name + " " + this.Birthday;
            }
        }

        class Car
        {
            private string model;
            private int speed;

            public Car() { }

            public Car(string model, int speed)
            {
                this.Model = model;
                this.Speed = speed;
            }

            public int Speed
            {
                get { return speed; }
                set { speed = value; }
            }

            public string Model
            {
                get { return model; }
                set { model = value; }
            }
        }
    }
}
