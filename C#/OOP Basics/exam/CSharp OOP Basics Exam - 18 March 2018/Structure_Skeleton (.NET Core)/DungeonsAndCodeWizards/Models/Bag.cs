namespace DungeonsAndCodeWizards.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private List<Item> items;

        public Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => Items.Select(a => a.Weight).Sum();

        public IReadOnlyCollection<Item> Items { get { return items.AsReadOnly(); } }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
                throw new InvalidOperationException("Bag is full!");

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
                throw new InvalidOperationException("Bag is empty!");

            Item searchedItem = this.Items.FirstOrDefault(i => i.GetType().Name == name);

            if (searchedItem == null)
                throw new ArgumentException(string.Format(OutputMessages.ItemNotFound, name));

            this.items.Remove(searchedItem);
            return searchedItem;
        }
    }
}
