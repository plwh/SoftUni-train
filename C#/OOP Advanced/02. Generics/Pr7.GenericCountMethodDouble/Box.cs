using System;
using System.Collections.Generic;
using System.Text;

public class Box<T> where T : IComparable<T>
{
    private T value;

    public Box(T t)
    {
        this.value = t;
    }
    
    public int CompareTo(T other)
    {
        return this.value.CompareTo(other);
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {this.value}";
    }
}
