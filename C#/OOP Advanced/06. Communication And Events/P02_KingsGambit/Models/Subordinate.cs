using P02_KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Models
{
    public abstract class Subordinate : ISubordinate
    {
        protected Subordinate(string name, string action)
        {
            this.Name = name;
            this.Action = action;
            this.IsAlive = true;
        }

        public string Name { get; }

        public bool IsAlive { get; private set; }

        public string Action { get; }

        public void Die()
        {
            this.IsAlive = false;
        }

        public virtual void ReactToAttack()
        {
            if (this.IsAlive)
            {
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
            }
        }
    }
}
