using System;

namespace P03_Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = null;
                Worker worker = null;

                for (int i = 0; i < 2; i++)
                {
                    string[] tokens = Console.ReadLine().Split();

                    string firstName = tokens[0];
                    string lastName = tokens[1];

                    if (i % 2 == 0)
                    {
                        string facultyNumber = tokens[2];

                        student = new Student(firstName, lastName, facultyNumber);
                    }
                    else
                    {
                        double weekSalary = double.Parse(tokens[2]);
                        int workHoursPerDay = int.Parse(tokens[3]);

                        worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);
                    }
                }

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
