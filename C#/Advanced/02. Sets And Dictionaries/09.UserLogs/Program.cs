using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string,int>> userLogs = new SortedDictionary<string, Dictionary<string,int>>();

            string line = Console.ReadLine();
            
            while (line != "end")
            {
                var input = line.Split(' ');

                string user = input[2].Substring(5, input[2].Length-5);
                string IP = input[0].Substring(3, input[0].Length-3);


                if (!userLogs.Keys.Contains(user))
                {
                    userLogs.Add(user, new Dictionary<string, int> { { IP, 1 } });
                }
                else
                {
                    if (!userLogs[user].ContainsKey(IP))
                    {
                        userLogs[user].Add(IP, 1);
                    }
                    else
                    {
                        userLogs[user][IP]++;
                    }
                }
                
                line = Console.ReadLine();
            }
            
            foreach(var users in userLogs)
            {
                int count = 0;
                Console.WriteLine($"{users.Key}:");
                foreach (var info in users.Value)
                {
                    if (count != users.Value.Count() - 1)
                    {
                        Console.Write($"{info.Key} => {info.Value}, ");
                    }
                    else
                    { 
                        Console.WriteLine($"{info.Key} => {info.Value}.");
                    }

                    count++;
                }
            }
        }
    }
}
