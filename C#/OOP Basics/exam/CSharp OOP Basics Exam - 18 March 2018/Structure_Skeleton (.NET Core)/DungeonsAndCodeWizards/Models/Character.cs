namespace DungeonsAndCodeWizards.Models
{
    using System;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoilnts, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoilnts;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(OutputMessages.InvalidName);

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get { return this.health; }
            set
            {
                this.health = Math.Min(value, this.BaseHealth);
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get { return this.armor; }
            set
            {
                this.armor = Math.Min(value, this.BaseArmor);
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; set; }

        protected virtual double RestHealMultiplier => 0.2;

        public void Rest()
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            double damage = Math.Max(0, hitPoints - this.Armor);
            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - damage);

            if (this.Health == 0)
                IsAlive = false;
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            this.UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
                throw new InvalidOperationException(OutputMessages.MustBeAlive);

            this.Bag.AddItem(item);
        }

        public override string ToString()
        {
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmor}, Status: {(this.IsAlive?"Alive":"Dead")}";
        }
    }
}
