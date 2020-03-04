using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CircleIntersect
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstCircleInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondCircleInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firtCircleCenter = new Point(firstCircleInput[0], firstCircleInput[1]);
            var fistCircleRad = firstCircleInput[2];

            var secondCircleCenter = new Point(secondCircleInput[0], secondCircleInput[1]);
            var secondCircleRad = secondCircleInput[2];

            var firstCircle = new Circle(firtCircleCenter, fistCircleRad);
            var secondCircle = new Circle(secondCircleCenter, secondCircleRad);

            Console.WriteLine(firstCircle.Intercepts(secondCircle) ? "Yes" : "No");
        }

        class Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }

        class Circle
        {
            public Circle(Point center, int radius)
            {
                this.Center = center;
                this.Radius = radius;
            }

            public Point Center { get; set; }

            public int Radius { get; set; }

            public bool Intercepts(Circle other)
            {
                var a = (double)(other.Center.X - this.Center.X);
                var b = (double)(other.Center.Y - this.Center.Y);

                var distanceBetweenCenters = Math.Sqrt(a * a + b * b);
                return distanceBetweenCenters <= this.Radius + other.Radius;
            }
        }


    }
}
