namespace DungeonsAndCodeWizards.Models
{
    using System;
    using DungeonsAndCodeWizards.Contracts;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            if (this.Faction != character.Faction)
                throw new InvalidOperationException(OutputMessages.CannotHealEnemy);

            character.Health += this.AbilityPoints;
            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}
