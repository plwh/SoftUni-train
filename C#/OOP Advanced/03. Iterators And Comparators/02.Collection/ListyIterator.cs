using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> list;
    private int index = 0;

    public ListyIterator()
    {
        this.list = new List<T>();
    }

    public ListyIterator(List<T> list)
    {
        this.list = list;
    }

    public bool Move()
    {
        if (index + 1 == list.Count)
        {
            return false;
        }

        index++;
        return true;
    }

    public bool HasNext()
    {
        if (index == list.Count - 1)
            return false;

        return true;
    }

    public void Print()
    {
        if (list.Count == 0)
            throw new InvalidOperationException("Invalid Operation!");

        Console.WriteLine(list[index]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < list.Count; i++)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
