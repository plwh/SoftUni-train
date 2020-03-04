using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            char[] delimitedChars = new char[] {',',' '};
            string line = Console.ReadLine();


            while (line != "end of dates")
            {
                List<string> input = line.Split(delimitedChars).ToList();

                string currUsername = input[0];
                input.Remove(currUsername);

                var curUserDates = new List<DateTime>();

                foreach (string date in input) curUserDates.Add(DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture));

                bool isPresent = false;

                foreach (var student in students)
                {
                    if (student.Name == currUsername)
                    {
                        isPresent = true;
                        student.AttDates.AddRange(curUserDates);
                        break;
                    }
                }
                if (isPresent == false)
                {
                    Student newStudent = new Student(currUsername,curUserDates,new List<string>());
                    students.Add(newStudent);
                }
                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "end of comments")
            {
                string[] comments = line.Split('-');
                string username = comments[0];
                string comment = comments[1];

                foreach (var student in students)
                {
                    if (student.Name == username)
                    {
                        student.Comments.Add(comment);
                        break;
                    }
                }

                line = Console.ReadLine();
            }

            PrintResults(students);
        }

        private static void PrintResults(List<Student> students)
        {
            foreach (var student in students.OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{student.Name}");
                Console.WriteLine("Comments:");
                foreach (var comment in student.Comments) Console.WriteLine("- " + comment);
                Console.WriteLine("Dates attended:");
                foreach (var date  in student.AttDates.OrderBy(x => x))
                {
                    Console.WriteLine("-- " + date.ToString("dd/MM/yyyy"));
                }
            }
        }
        
        class Student
        {
            public Student(string name, List<DateTime> attDates, List<string> comments)
            {
                this.Name = name;
                this.Comments = comments;
                this.AttDates = attDates;
            }

            public string Name { get; set; }
            public List<string> Comments { get; set; }
            public List<DateTime> AttDates { get; set; }
        }
    }
}
