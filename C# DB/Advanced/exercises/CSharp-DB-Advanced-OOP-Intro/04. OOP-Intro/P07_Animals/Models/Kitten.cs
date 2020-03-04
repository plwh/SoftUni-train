using System;
using System.Collections.Generic;
using System.Text;

namespace P07_Animals
{
    public class Kitten : Animal
    {
        public Kitten(string name, int age) 
            : base(name, age, "Female")
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
