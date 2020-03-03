using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Program
    {
        private const int maxBedsInDepartment = 60;

        static void Main(string[] args)
        {
            var departmentsInfo = new Dictionary<string, HashSet<string>>();
            var doctorsInfo = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Output")
                    break;

                var info = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var departmentName = info[0];
                var doctorName = info[1] + " " + info[2];
                var patientName = info[3];

                if (!departmentsInfo.ContainsKey(departmentName))
                {
                    departmentsInfo[departmentName] = new HashSet<string>();
                }

                if (!doctorsInfo.ContainsKey(doctorName))
                {
                    doctorsInfo[doctorName] = new HashSet<string>();
                }

                if (departmentsInfo[departmentName].Count >= maxBedsInDepartment)
                {
                    continue;
                }

                departmentsInfo[departmentName].Add(patientName);
                doctorsInfo[doctorName].Add(patientName);
            }

            while (true)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "End")
                    break;

                int countOfSearchedElements = input.Length;
                switch (countOfSearchedElements)
                {
                    case 1:
                        string targetDepartment = input[0];
                        if (departmentsInfo.ContainsKey(targetDepartment))
                        {
                            departmentsInfo[targetDepartment].ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        break;
                    case 2:
                        string targetDoctor = input[0] + " " + input[1];
                        if (doctorsInfo.ContainsKey(targetDoctor))
                        {
                            doctorsInfo[targetDoctor].OrderBy(x => x)
                                .ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        else
                        {
                            string currDepartment = input[0];
                            int targetRoom = int.Parse(input[1]);

                            departmentsInfo[currDepartment]
                                .Skip((targetRoom * 3) - 3)
                                .Take(3)
                                .OrderBy(x => x)
                                .ToList()
                                .ForEach(p => Console.WriteLine(p));
                        }
                        break;
                }
            }
        }
    }
}
