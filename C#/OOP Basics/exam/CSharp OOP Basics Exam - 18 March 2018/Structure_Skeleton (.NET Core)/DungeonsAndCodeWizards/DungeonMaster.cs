namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Factories;
    using DungeonsAndCodeWizards.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private List<Character> party;
        private Stack<Item> itemPool;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
            this.party = new List<Character>();
            this.itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            this.party.Add(this.characterFactory.CreateCharacter(args[0],args[1],args[2]));

            return string.Format(OutputMessages.JoinedParty, args[2]);
        }

        public string AddItemToPool(string[] args)
        {
            this.itemPool.Push(this.itemFactory.CreateItem(args[0]));

            return string.Format(OutputMessages.ItemAdded, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.party.FirstOrDefault(a => a.Name == characterName);
            if (character == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, characterName));

            if (this.itemPool.Count == 0)
                throw new InvalidOperationException(OutputMessages.NoItemsLeft);

            Item item = this.itemPool.Pop();
            character.ReceiveItem(item);

            return string.Format(OutputMessages.ItemPickedUp, character.Name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.party.FirstOrDefault(a => a.Name == characterName);
            if (character == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, characterName));

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(OutputMessages.ItemUsed, character.Name, item.GetType().Name);
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.party.FirstOrDefault(a => a.Name == giverName);
            if(giver == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, giverName));
            Character receiver = this.party.FirstOrDefault(a => a.Name == receiverName);
            if (receiver == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, receiverName));

            Item item = giver.Bag.GetItem(itemName);

            receiver.UseItem(item);

            return string.Format(OutputMessages.ItemUsedOn, giver.Name, item.GetType().Name, receiver.Name);
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = this.party.FirstOrDefault(a => a.Name == giverName);
            if (giver == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, giverName));
            Character receiver = this.party.FirstOrDefault(a => a.Name == receiverName);
            if (receiver == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, receiverName));

            Item item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return string.Format(OutputMessages.ItemGiven, giver.Name, receiver.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            var characters = party
                .OrderByDescending(c => c.IsAlive)
                .OrderByDescending(c => c.Health)
                .ToList();

            foreach (Character character in characters)
                sb.AppendLine(character.ToString());

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.party.FirstOrDefault(a => a.Name == attackerName);
            if (attacker == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, attackerName));
            Character receiver = this.party.FirstOrDefault(a => a.Name == receiverName);
            if (receiver == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, receiverName));

            if (!(attacker is IAttackable attackerChar))
                throw new ArgumentException(string.Format(OutputMessages.CannotAttack, attacker.Name));

            attackerChar.Attack(receiver);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.SuccessfulAttack, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
                sb.AppendLine(string.Format(OutputMessages.CharacterDead, receiver.Name));

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.party.FirstOrDefault(a => a.Name == healerName);
            if (healer == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, healerName));
            Character healingReceiver = this.party.FirstOrDefault(a => a.Name == healingReceiverName);
            if (healingReceiver == null)
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, healingReceiverName));

            if (!(healer is IHealable healerChar))
                throw new ArgumentException(string.Format(OutputMessages.CannotHeal, healer.Name));

            healerChar.Heal(healingReceiver);

            return String.Format(OutputMessages.SuccessfulHeal, healer.Name, healingReceiver.Name, healer.AbilityPoints, healingReceiver.Health);
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach(var character in party.Where(a => a.IsAlive))
            {
                double prevHealth = character.Health;
                character.Rest();

                sb.AppendLine(string.Format(OutputMessages.Rest, character.Name, prevHealth, character.Health));
            }

            if (this.party.Count(c => c.IsAlive) <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return sb.ToString().Trim();
        }

        public bool IsGameOver()
        {
            return this.party.Count(c => c.IsAlive) <= 1 && this.lastSurvivorRounds > 1;
        }
    }
}
