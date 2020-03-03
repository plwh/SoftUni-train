namespace DungeonsAndCodeWizards.Models
{
    using System;

    public class PoisonPotion : Item
    {
        public PoisonPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            character.Health -= 20;
            character.Health = Math.Max(0, character.Health);

            if (character.Health == 0)
                character.IsAlive = false;
        }
    }
}
