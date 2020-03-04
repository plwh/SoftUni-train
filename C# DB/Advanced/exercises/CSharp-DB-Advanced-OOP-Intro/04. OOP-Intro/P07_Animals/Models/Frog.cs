using System;
using System.Collections.Generic;
using System.Text;

namespace P07_Animals
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}
