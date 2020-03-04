using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AvgGradse
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < num; i++)
            {
                string input = Console.ReadLine();
                string[] studentInfo = input.Split(' ');
                string studentName = studentInfo[0];
                List<double> studentMarks = new List<double>();
                foreach (string info in studentInfo) if (double.TryParse(info, out double mark)) studentMarks.Add(mark);

                students.Add(new Student(studentName,studentMarks));
            }

            var results = students.Where(x => x.AverageGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

            foreach (var result in results)
            {
                Console.WriteLine($"{result.Name} -> {result.AverageGrade:F2}");
            }        
        }

        class Student
        {
            public Student(string name, List<double> grades)
            {
                this.Name = name;
                this.Grades = grades;
            }

            public string Name { get; set; }

            public List<double> Grades { get; set; }

            public double AverageGrade
            {
                get { return Grades.Average(); }
            }
        }
    }
}
