using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var excludedCommands = new Dictionary<string, List<int>>();

            string line = Console.ReadLine();
            while (line != "Forge")
            {
                string [] commandTokens = line.Split(';');

                string command = commandTokens[0];
                string filterType = commandTokens[1];
                int filterParameter = int.Parse(commandTokens[2]);

                if (command == "Exclude")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        int currSum = 0;

                        switch (filterType)
                        {
                            case "Sum Left":
                                if (i == 0)
                                {
                                    currSum += numbers[i];
                                }
                                else
                                {
                                    currSum += numbers[i - 1] + numbers[i];
                                }
                                break;

                            case "Sum Right":
                                if (i == numbers.Count - 1)
                                {
                                    currSum += numbers[i];
                                }
                                else
                                {
                                    currSum += numbers[i] + numbers[i + 1];
                                }
                                break;

                            case "Sum Left Right":
                                if (numbers.Count == 1)
                                {
                                    currSum += numbers[i];
                                }
                                else
                                { 
                                    if (i == 0)
                                    {
                                        currSum += numbers[i] + numbers[i + 1];
                                    }
                                    else if (i == numbers.Count - 1)
                                    {
                                        currSum += numbers[i - 1] + numbers[i];
                                    }
                                    else
                                    {
                                        currSum += numbers[i - 1] + numbers[i] + numbers[i + 1];
                                    }
                                }
                                break;
                        }
                        
                        if (currSum == filterParameter)
                        {
                            if (!excludedCommands.ContainsKey(filterType + filterParameter))
                            {
                                excludedCommands.Add(filterType + filterParameter, new List<int>() {numbers[i]});
                            }
                            else
                            {
                                excludedCommands[filterType + filterParameter].Add(numbers[i]);
                            }
                        }
                    }

                }
                else if(command == "Reverse")
                {
                    excludedCommands.Remove(filterType+filterParameter);
                }

                line = Console.ReadLine();
            }

            var numbersToExclude = excludedCommands.SelectMany(d => d.Value).ToList();
            numbers = numbers.Where(a => !numbersToExclude.Contains(a)).ToList();

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
