using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ExternalEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int poorCount = 0;
            int satisfactoryCount = 0;
            int goodCount = 0;
            int veryGoodCount = 0;
            int excellentCount = 0;

            for (int i = 0; i < n; i++)
            {
                float currMark = float.Parse(Console.ReadLine());

                if (currMark >= 0 && currMark <= 22.5)
                {
                    poorCount++;
                }
                else if (currMark >= 22.5 && currMark <= 40.5)
                {
                    satisfactoryCount++;
                }
                else if (currMark >= 40.5 && currMark <= 58.5)
                {
                    goodCount++;
                }
                else if (currMark >= 58.5 && currMark <= 76.5)
                {
                    veryGoodCount++;
                }
                else if (currMark >= 76.5 && currMark <= 100)
                {
                    excellentCount++;
                }
            }
            Console.WriteLine("{0:F2}% poor marks", (float)(poorCount)/ n * 100);
            Console.WriteLine("{0:F2}% satisfactory marks", (float)(satisfactoryCount) / n * 100);
            Console.WriteLine("{0:F2}% good marks",(float)(goodCount) / n * 100);
            Console.WriteLine("{0:F2}% very good marks", (float)(veryGoodCount) / n * 100);
            Console.WriteLine("{0:F2}% excellent marks", (float)(excellentCount) / n * 100);
        }
    }
}
