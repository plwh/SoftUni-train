using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChangeList
{
    class Program
    {
        static bool IsEven(int num)
        {
            if (num % 2 == 0) return true;

            return false;
        }

        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            

            while (true)
            {
                string [] commands = Console.ReadLine().Split(' ');

                if (commands[0] == "Odd")
                {
                    foreach (int num in numbers)
                    {
                        if (!IsEven(num)) Console.Write(num + " ");
                    }
                    break;
                }
                else if (commands[0] == "Even")
                {
                    foreach (int num in numbers)
                    {
                        if (IsEven(num)) Console.Write(num + " ");
                    }
                    break;
                }
                else
                {
                    switch (commands[0])
                    {
                        case "Delete":
                            int numberToRemove = int.Parse(commands[1]);
                            numbers.RemoveAll(item => item == numberToRemove);
                            break;
                        case "Insert":
                            int numberToInsert = int.Parse(commands[1]);
                            int position = int.Parse(commands[2]);
                            numbers.Insert(position,numberToInsert);
                            break;
                    }
                }
            }
        }
    }
}
