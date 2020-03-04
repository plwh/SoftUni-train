using System;
using System.Net;

namespace P01_URL_Decode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var encodedUrl = Console.ReadLine();

            string decodedUrl = WebUtility.UrlDecode(encodedUrl);

            Console.WriteLine(decodedUrl);
        }
    }
}
