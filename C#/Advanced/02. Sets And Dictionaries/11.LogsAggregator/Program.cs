using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> userData = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currData = Console.ReadLine().Split(' ');

                string ipAddress = currData[0];
                string user = currData[1];
                int duration = int.Parse(currData[2]);

                if (!userData.ContainsKey(user))
                {
                    userData.Add(user, new Dictionary<string, int> { { ipAddress, duration } });
                }
                else
                {
                    if (!userData[user].ContainsKey(ipAddress))
                    {
                        userData[user].Add(ipAddress, duration);
                    }
                    else
                    {
                        userData[user][ipAddress] += duration;
                    }
                }
            }

            foreach (var users in userData.OrderBy(x => x.Key))
            {
                Console.Write($"{users.Key}: {users.Value.Values.Sum()} [{string.Join(", ", users.Value.OrderBy(x => x.Key).Select(x => x.Key))}]\n");
            }
        }
    }
}
