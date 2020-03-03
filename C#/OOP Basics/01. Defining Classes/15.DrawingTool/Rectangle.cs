using System;
using System.Collections.Generic;
using System.Text;

class Rectangle : Shape
{
    public int width;
    public int length;

    public Rectangle(int width, int length)
    {
        this.Width = width;
        this.Length = length;
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }

    public override void Draw()
    {
        for (int i = 0; i < this.Length; i++)
        {
            if (i == 0 || i == this.Length - 1)
            {
                Console.WriteLine($"|{new string('-', this.Width)}|");
            }
            else
            {
                Console.WriteLine($"|{new string(' ', this.Width)}|");
            }
        }
    }
}

