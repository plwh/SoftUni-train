using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomStack<T> : IEnumerable<T>
{
    private T[] array;

    public CustomStack()
    {
        this.array = new T[4]; 
    }

    public int InnerArraySize => this.array.Length;
    
    public int Count { get; private set;}

    public void Push(T element)
    {
        this.Count++;

        if (this.Count > this.InnerArraySize)
        {
            T[] newArray = new T[this.InnerArraySize + 1];
            Array.Copy(this.array, newArray, this.InnerArraySize);
            this.array = newArray;
        }

        this.array[this.Count - 1] = element;
    }

    public T Pop()
    {
        if (this.Count  == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        T element = this.array[this.InnerArraySize - 1];

        this.array = this.array.Take(this.InnerArraySize - 1).ToArray();

        this.Count--;

        return element;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = array.Length-1; i >= 0; i--)
        {
            yield return array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
