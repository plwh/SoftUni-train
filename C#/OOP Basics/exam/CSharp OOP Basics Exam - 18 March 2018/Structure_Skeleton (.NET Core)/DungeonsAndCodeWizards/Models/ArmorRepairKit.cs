namespace DungeonsAndCodeWizards.Models
{
    using System;

    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() 
            : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            character.Armor = character.BaseArmor;
        }
    }
}
