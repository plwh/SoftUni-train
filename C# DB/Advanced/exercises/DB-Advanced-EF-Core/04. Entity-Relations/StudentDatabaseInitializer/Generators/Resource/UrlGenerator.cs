using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabaseInitializer.Generators.Resource
{
    public class UrlGenerator
    {
        internal static string GenerateUrl()
        {
            string resourceName = ResourceNameGenerator.GeneratedName.Split()[0];

            return $"http://www.wikipedia.org/{resourceName.ToLower()}_resource";
        }
    }
}
