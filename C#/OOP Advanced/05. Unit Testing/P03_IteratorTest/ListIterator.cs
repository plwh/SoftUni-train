namespace P03_IteratorTest
{
    using System;
    using System.Collections.Generic;

    public class ListIterator<T>
    {
        private int currentIndex = 0;

        public ListIterator(IEnumerable<T> items)
        {
            this.Items = new List<T>();

            if (items is null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }

        public IList<T> Items { get; private set; }

        public bool Move()
        {
            if (this.HasNext())
            {
                currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.Items[currentIndex]);
        }

        public bool HasNext()
        {
            if (currentIndex + 1 < this.Items.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
