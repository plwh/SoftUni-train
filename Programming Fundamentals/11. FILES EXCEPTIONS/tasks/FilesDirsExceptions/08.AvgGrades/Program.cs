using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.AvgGrades
{
        class Program
        {
            static void Main(string[] args)
            {

                List<Student> students = new List<Student>();
                string[] input = File.ReadAllLines("../../input.txt");
                int num = int.Parse(input[0].ToString());
                for (int i = 1; i <= num; i++)
                {
                    string[] studentInfo = input[i].Split(' ');
                    string studentName = studentInfo[0];
                    List<double> studentMarks = new List<double>();
                    foreach (string info in studentInfo) if (double.TryParse(info, out double mark)) studentMarks.Add(mark);

                    students.Add(new Student(studentName, studentMarks));
                }

                var results = students.Where(x => x.AverageGrade >= 5.00).OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrade);

                foreach (var result in results)
                {
                    File.AppendAllText("../../output.txt",$"{result.Name} -> {result.AverageGrade:F2}{Environment.NewLine}");
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
