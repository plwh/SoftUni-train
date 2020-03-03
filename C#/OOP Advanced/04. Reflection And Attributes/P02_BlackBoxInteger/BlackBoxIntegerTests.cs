namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var constructor = typeof(BlackBoxInteger).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            var instance = (BlackBoxInteger)constructor.Invoke(null);

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('_');

                string methodName = tokens[0];
                int parameter = int.Parse(tokens[1]);

                MethodInfo method = typeof(BlackBoxInteger).GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
                
                method.Invoke(instance,new object[] {parameter});
                FieldInfo field = typeof(BlackBoxInteger).GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}
