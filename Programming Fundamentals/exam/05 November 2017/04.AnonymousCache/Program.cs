using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AnonymousCache
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            var data = new Dictionary<string,Dictionary<string,long>>();
            var cache = new Dictionary<string, Dictionary<string, long>>();
            var delimitedChars = new char[] {' ','-','>','|'};

            while (inputLine!= "thetinggoesskrra")
            {
                string[] inputParams = inputLine.Split(delimitedChars,StringSplitOptions.RemoveEmptyEntries);

                if (inputParams.Length == 1)
                {
                    string dataSet = inputParams[0];

                    if (cache.ContainsKey(dataSet))
                    {
                        data[dataSet] = new Dictionary<string, long>(cache[dataSet]);
                        cache.Remove(dataSet);
                    }
                    else
                    {
                        data[dataSet] = new Dictionary<string, long>();
                    }
                }
                else
                {
                    string dataKey = inputParams[0];
                    long dataSize = long.Parse(inputParams[1]);
                    string dataSet = inputParams[2];

                    if (!data.ContainsKey(dataSet))
                    {
                        if (!cache.ContainsKey(dataSet))
                        {
                            cache[dataSet] = new Dictionary<string, long>();
                        }
                        
                        cache[dataSet][dataKey] = dataSize;
                    }
                    else
                    {
                        data[dataSet][dataKey] = dataSize;
                    }
                }

                inputLine = Console.ReadLine();
            }

            if (data.Count > 0)
            {
                KeyValuePair<string, Dictionary<string, long>> result = data
                   .OrderByDescending(ds => ds.Value.Sum(d => d.Value)) 
                   .First();

                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(d => d.Value)}");

                foreach (var value in result.Value)
                {
                    //Just printing
                    Console.WriteLine($"$.{value.Key}");
                }
            }
        }
    }
}
