using System;
using System.Text.RegularExpressions;

namespace P02_Validate_URL
{
    class Program
    {
        private static string ValidUrlSummaryTemplate = @"Protocol: {0}
Host: {1}
Port: {2}
Path: {3}
Query: {4}
Fragment: {5}";

        static void Main(string[] args)
        {
            var urlPattern =
                @"^((http|https):\/(\/[0-9a-zA-Z\-\.]+)(?:\:(\d+))?)((\/{0,1}[0-9a-zA-Z\-\.\/]+)*)?(\?[0-9a-zA-Z\-\.\=\+\&_]+)?(\#[0-9a-zA-Z\-\.]+)?$";

            var urlMatcher = new Regex(urlPattern);

            var inputUrl = Console.ReadLine();
            var matchedUrl = urlMatcher.Match(inputUrl);

            if (matchedUrl.Success)
            {
                var matches = matchedUrl.Groups;
                var protocolMatch = matches[2].ToString();
                var portMatch = matches[4].ToString();

                if (protocolMatch == "https")
                {
                    if (string.IsNullOrEmpty(portMatch) ||
                        portMatch != "443")
                    {
                        Console.WriteLine("Invalid URL");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(portMatch) && 
                        portMatch != "80")
                    {
                        Console.WriteLine("Invalid URL");
                    }
                }

                var hostMatch = matches[3].ToString();
                var pathMatch = matches[6].ToString();
                var queryMatch = matches[7].ToString();
                var fragmentMatch = matches[8].ToString();

                var validUrl = string.Format(
                    ValidUrlSummaryTemplate,
                    protocolMatch,
                    hostMatch,
                    portMatch,
                    pathMatch,
                    queryMatch,
                    fragmentMatch);

                Console.WriteLine(validUrl);
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
