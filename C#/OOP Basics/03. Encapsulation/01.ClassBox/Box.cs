using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public double CalcSurfaceArea()
    {
        return (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    }

    public double CalcLateralSurfaceArea()
    {
        return (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
    }

    public double CalcVolume()
    {
        return this.Length * this.Width * this.Height;
    }
}
