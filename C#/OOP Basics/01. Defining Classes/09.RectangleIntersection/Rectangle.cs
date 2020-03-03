using System;
using System.Collections.Generic;
using System.Text;

class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double topLeftX;
    private double topLeftY;

    public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.TopLeftX = topLeftX;
        this.TopLeftY = topLeftY;
    }
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public double TopLeftX
    {
        get { return topLeftX; }
        set { topLeftX = value; }
    }

    public double TopLeftY
    {
        get { return topLeftY; }
        set { topLeftY = value; }
    }

    public bool CheckIntersect(Rectangle secondRectangle)
    {
        if (Math.Abs(this.TopLeftX) < Math.Abs(secondRectangle.TopLeftX + secondRectangle.Width))
        {
            if (Math.Abs(this.TopLeftX + this.Width) >= Math.Abs(secondRectangle.TopLeftX))
            {
                if (this.TopLeftY < Math.Abs((secondRectangle.TopLeftY - secondRectangle.Height)))
                {
                    if (Math.Abs(this.TopLeftY + this.Height) >= Math.Abs(secondRectangle.topLeftY))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
