namespace P03_IteratorTest.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        private static void Main()
        {
            ListIterator<string> iterator = new ListIterator<string>(new string[0]);

            string input = "";

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split();

                try
                { 
                    switch (data[0])
                    {
                        case "Create":
                            string[] dataToAdd = new string[data.Length - 1];
                            for (int i = 0; i < dataToAdd.Length; i++)
                            {
                                dataToAdd[i] = data[i + 1];
                            }
                            iterator = new ListIterator<string>(dataToAdd);
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                        case "Print":
                            iterator.Print();
                            break;
                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
