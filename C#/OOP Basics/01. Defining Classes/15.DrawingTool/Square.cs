using System;
using System.Collections.Generic;
using System.Text;

class Square : Shape
{
    public int size;

    public Square(int size)
    {
        this.Size = size;
    }

    public int Size
    {
        get { return size; }
        set { size = value; }
    }

    public override void Draw()
    {
        for (int i = 0; i < this.Size; i++)
        {
            if (i == 0 || i == this.Size - 1)
            {
                Console.WriteLine($"|{new string('-', this.Size)}|");
            }
            else
            {
                Console.WriteLine($"|{new string(' ', this.Size)}|");
            }
        }
    }
}
