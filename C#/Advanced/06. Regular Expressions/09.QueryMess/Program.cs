using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.QueryMess
{
    class Program
    {
        static void Main(string[] args)
        {
          

            var line = Console.ReadLine();

            while (line != "END")
            {
                var pairs = line.Split('&');
                var dictionary = new Dictionary<string, List<string>>();

                foreach (string pair in pairs)
                {
                    var pairData = pair.Split('=');

                    var key = pairData[0].Replace("%20", " ").Replace("+", " ").Trim();
                    if (key.Contains('?'))
                    {
                        key = key.Substring(key.IndexOf('?') + 1, key.Length - key.IndexOf('?') - 1);
                    }

                    var value = pairData[1].Replace("%20", " ").Replace("+", " ").Trim();
                    value = Regex.Replace(value, @"\s+"," ");

                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary[key] = new List<string>() {value};
                    }
                    else
                    {
                        dictionary[key].Add(value);
                    }
                }
                
                foreach (var result in dictionary)
                {
                    Console.Write(result.Key + "=" + "[" + String.Join(", ", result.Value) + "]");
                }
                Console.WriteLine();

                line = Console.ReadLine();
            }
        }
    }
}
