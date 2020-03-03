namespace DungeonsAndCodeWizards.Models
{
    using System;
    using DungeonsAndCodeWizards.Contracts;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) 
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            if (this.Name == character.Name)
                throw new InvalidOperationException(OutputMessages.SelfAttack);

            if (this.Faction == character.Faction)
                throw new ArgumentException(string.Format(OutputMessages.FriendlyFire, this.Faction));

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
