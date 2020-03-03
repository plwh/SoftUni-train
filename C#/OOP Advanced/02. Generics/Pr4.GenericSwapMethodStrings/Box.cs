using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
    private T value;

    public Box(T t)
    {
        this.value = t;
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {this.value}";
    }
}
