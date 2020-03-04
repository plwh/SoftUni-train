using System;
using System.Collections.Generic;
using System.Text;

namespace P07_Animals
{
    public class Tomcat : Animal
    {
        public Tomcat(string name, int age) 
            : base(name, age, "Male")
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("MEOW");
        }
    }
}
