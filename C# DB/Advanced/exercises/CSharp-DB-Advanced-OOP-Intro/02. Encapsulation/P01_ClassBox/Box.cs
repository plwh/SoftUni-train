using System;
using System.Collections.Generic;
using System.Text;

namespace P01_ClassBox
{
    public class Box
    {
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get; private set; }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public double CalcVolume()
        {
            return this.Length * this.Width * this.Height;
        }

        public double CalcLatSurfArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double CalcSurfArea()
        {
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }
    }
}
