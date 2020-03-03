namespace DungeonsAndCodeWizards.Models
{
    using System;

    public class HealthPotion : Item
    {
        public HealthPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            character.Health += 20;
        }
    }
}
