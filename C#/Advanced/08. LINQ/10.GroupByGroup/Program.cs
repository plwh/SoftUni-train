using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.GroupByGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsData = new List<Person>();

            var line = Console.ReadLine();
            while (line != "END")
            {
                var tokens = line.Split(' ');
                studentsData.Add(new Person(tokens[0] + " " + tokens[1], int.Parse(tokens[2])));
                line = Console.ReadLine();
            }

            var grouped = studentsData
                .GroupBy(a => a.Group)
                .OrderBy(gr => gr.Key);

            foreach (var group in grouped)
            {
                Console.Write(group.Key + " - ");
                Console.WriteLine(String.Join(", ", group));
            }
        }

        public class Person
        {
            public string Name { get; set; }
            public int Group { get; set; }

            public Person(string name, int group)
            {
                this.Name = name;
                this.Group = group;
            }

            public override string ToString()
            {
                string result = this.Name;
                return result;
            }
        }
    }
}
