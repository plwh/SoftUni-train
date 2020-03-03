using System;

namespace _03.Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split();

                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string facNumber = studentInfo[2];

                Student student = new Student(firstName, lastName, facNumber);

                string[] workerInfo = Console.ReadLine().Split();

                firstName = workerInfo[0];
                lastName = workerInfo[1];
                decimal weekSalary = decimal.Parse(workerInfo[2]);
                decimal workHoursPerDay = decimal.Parse(workerInfo[3]);

                Worker worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
