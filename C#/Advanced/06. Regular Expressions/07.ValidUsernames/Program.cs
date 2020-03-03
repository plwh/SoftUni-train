using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var usernames = Console.ReadLine().Split(new char[] { '/', '\\', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> validUsernames = new List<string>();
            int maxSum = 0;
            int startIndex = 0;

            foreach (string username in usernames)
                if (IsValidUsername(username)) validUsernames.Add(username);
              
            for (int i = 1; i < validUsernames.Count; i++)
            {
                int currSum = validUsernames[i - 1].Length + validUsernames[i].Length;

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    startIndex = i - 1;
                }
            }
            
            Console.WriteLine($"{validUsernames[startIndex]}\n{validUsernames[startIndex+1]}");
        }

        private static bool IsValidUsername(string v)
        {
            Regex rgx = new Regex(@"\b[A-za-z][A-za-z0-9_]{2,24}\b");
            if (rgx.IsMatch(v))
            {
                return true;
            }
            return false;
        }
    }
}
