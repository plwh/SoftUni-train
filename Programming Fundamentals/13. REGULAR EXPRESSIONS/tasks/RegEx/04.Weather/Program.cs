using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            var input = Console.ReadLine();
            var dictionary = new Dictionary<string, KeyValuePair<float, string>>();
            var pattern = @"([A-Z]{2})([0-9]{1,2}.[0-9]{1,2})([A-Za-z]+)\|";

            while (input != "end")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string city = match.Groups[1].Value;
                    float temp = float.Parse(match.Groups[2].Value);
                    string typeOfWeather = match.Groups[3].Value;

                    if (!dictionary.ContainsKey(city))
                    {
                        dictionary[city] = new KeyValuePair<float, string>(temp, typeOfWeather);
                    }
                    else
                    {
                        dictionary[city] = new KeyValuePair<float, string>(temp, typeOfWeather);
                    }
                }

                input = Console.ReadLine();
            }

            var sortedDict = dictionary.OrderBy(x => x.Value.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var d in sortedDict)
            {
                Console.WriteLine($"{d.Key} => {d.Value.Key:f2} => {d.Value.Value}");
            }
        }
    }
}
