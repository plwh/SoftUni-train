using P02_KingsGambit.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Models
{
    public abstract class Subordinate : ISubordinate
    {
        protected Subordinate(string name, string action, int hitpoints)
        {
            this.Name = name;
            this.Action = action;
            this.HitPoints = hitpoints;
            this.IsAlive = true;
        }

        public string Name { get; }

        public bool IsAlive { get; private set; }

        public string Action { get; }

        public int HitPoints { get; private set; }

        public event SubordinateDeathEventHandler DeathEvent;

        public void Die()
        {
            this.IsAlive = false;
            if (this.DeathEvent != null)
            {
                this.DeathEvent.Invoke(this);
            }
        }

        public virtual void ReactToAttack()
        {
            if (this.IsAlive)
            {
                Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}!");
            }
        }

        public void TakeDamage()
        {
            this.HitPoints--;
            if (this.HitPoints <= 0)
            {
                this.Die();
            }
        }
    }
}
