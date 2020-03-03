using System;
using System.Collections.Generic;
using System.Linq;

namespace Pr2._BusinessLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            DraftManager minedraft = new DraftManager();

            string line = "";
            while ((line = Console.ReadLine()) != "Shutdown")
            {
                List<string> tokens = line.Split().ToList();
                string command = tokens[0];
                tokens.RemoveAt(0);

                try
                {
                    switch (command)
                    {
                        case "RegisterHarvester":
                            Console.WriteLine(minedraft.RegisterHarvester(tokens));
                            break;
                        case "RegisterProvider":
                            Console.WriteLine(minedraft.RegisterProvider(tokens));
                            break;
                        case "Day":
                            Console.WriteLine(minedraft.Day());
                            break;
                        case "Mode":
                            Console.WriteLine(minedraft.Mode(tokens[0]));
                            break;
                        case "Check":
                            Console.WriteLine(minedraft.Check(tokens[0]));
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(minedraft.ShutDown());   
        }
    }
}
