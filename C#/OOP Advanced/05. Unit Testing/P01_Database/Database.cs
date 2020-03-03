namespace P01_Database
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Database<T>
    {
        private const int defaultCapacity = 16;

        private T[] values;
        private int currentIndex;

        public Database()
        {
            this.values = new T[defaultCapacity];
            this.currentIndex = 0;
        }

        public Database(params T[] values)
            : this()
        {
            this.InitializeValues(values);
        }

        public int Count { get { return this.currentIndex; } }

        private void InitializeValues(T[] inputValues)
        {
            try
            {
                // inputValues = inputValues.Concat(inputValues).ToArray();
                Array.Copy(inputValues, this.values, inputValues.Length);
                this.currentIndex = inputValues.Length;
            }
            catch (ArgumentException e)
            {
                throw new InvalidOperationException("Array is full!", e);
            }
        }

        public virtual void Add(T element)
        {
            if (this.currentIndex >= defaultCapacity)
            {
                throw new InvalidOperationException("Array is full!");
            }

            this.values[this.currentIndex] = element;
            this.currentIndex++;
        }

        public T Remove()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }

            this.currentIndex--;
            T removedItem = this.values[currentIndex];
            this.values[currentIndex] = default(T);

            return removedItem;
        }

        public T[] Fetch()
        {
            T[] newArray = new T[this.currentIndex];
            Array.Copy(this.values, newArray, this.currentIndex);

            return newArray;}
    }
}
