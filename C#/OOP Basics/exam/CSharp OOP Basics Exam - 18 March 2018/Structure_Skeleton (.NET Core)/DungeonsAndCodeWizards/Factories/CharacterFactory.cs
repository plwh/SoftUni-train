using DungeonsAndCodeWizards.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse(faction, out Faction curentFaction))
                throw new ArgumentException(string.Format(OutputMessages.InvalidFaction, faction));

            if (characterType == "Warrior")
            {
                return new Warrior(name, curentFaction);
            }
            else if(characterType == "Cleric")
            { 
                return new Cleric(name, curentFaction);
            }

            throw new ArgumentException(string.Format(OutputMessages.InvalidCharacter, characterType));
        }
    }
}
