 namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type myType = typeof(HarvestingFields);
            FieldInfo[] fields;
            List<FieldInfo> allFields = new List<FieldInfo>();
            string input = "";

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                switch (input)
                {
                    case "public":
                        fields = myType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                        AppendFields(fields, allFields);
                        break;
                    case "protected":
                        fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                            .Where(x => x.IsFamily)
                            .ToArray();
                        AppendFields(fields, allFields);
                        break;
                    case "private":
                        fields = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                            .Where(x => x.IsPrivate)
                            .ToArray();
                        AppendFields(fields, allFields);
                        break;
                    case "all":
                        fields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        AppendFields(fields, allFields);
                        break;
                }
            }

            foreach (FieldInfo field in allFields)
            {
                Console.WriteLine(@"{0} {1} {2}", (field.IsFamily)?"protected":field.Attributes.ToString().ToLower(), field.FieldType.Name, field.Name);
            }
        }

        private static void AppendFields(FieldInfo[] fields, List<FieldInfo> allFields)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                allFields.Add(fields[i]);
            }
        }
    }
}
