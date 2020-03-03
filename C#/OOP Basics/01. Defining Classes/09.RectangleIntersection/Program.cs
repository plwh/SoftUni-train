using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int[] nAndM = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = nAndM[0];
            int m = nAndM[1];

            for (int i = 0; i < n; i++)
            {
                string[] rectangleInfo = Console.ReadLine().Split();

                string currentId = rectangleInfo[0];
                double width = double.Parse(rectangleInfo[1]);
                double height = double.Parse(rectangleInfo[2]);
                double topLeftX = double.Parse(rectangleInfo[3]);
                double topLeftY = double.Parse(rectangleInfo[4]);

                rectangles.Add(new Rectangle(currentId,width,height,topLeftX,topLeftY));
            }

            for (int i = 0; i < m; i++)
            {
                string[] pairs = Console.ReadLine().Split();

                Rectangle firstRectangle = rectangles.Find(a => a.Id == pairs[0]);
                Rectangle secondRectangle = rectangles.Find(a => a.Id == pairs[1]);

                Console.WriteLine(firstRectangle.CheckIntersect(secondRectangle)?"true":"false");
            }
        }
    }
}
