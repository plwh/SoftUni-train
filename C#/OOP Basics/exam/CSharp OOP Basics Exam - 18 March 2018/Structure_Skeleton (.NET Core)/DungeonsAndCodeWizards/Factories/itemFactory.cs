using DungeonsAndCodeWizards.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string itemType)
        {
            if (itemType == "ArmorRepairKit")
            {
                return new ArmorRepairKit();
            }
            else if (itemType == "HealthPotion")
            {
                return new HealthPotion();
            }
            else if (itemType == "PoisonPotion")
            {
                return new PoisonPotion();
            }

            throw new ArgumentException(string.Format(OutputMessages.InvalidItem, itemType));
        }
    }
}
