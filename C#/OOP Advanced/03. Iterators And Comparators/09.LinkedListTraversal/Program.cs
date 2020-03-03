using System;

namespace _09.LinkedListTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "Add":
                        int elementToAdd = int.Parse(commands[1]);
                        list.Add(elementToAdd);
                        break;
                    case "Remove":
                        int elementToRemove = int.Parse(commands[1]);
                        list.Remove(elementToRemove);
                        break;
                }
            }
            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
