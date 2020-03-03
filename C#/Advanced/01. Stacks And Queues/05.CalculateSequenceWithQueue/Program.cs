using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();

            int N = int.Parse(Console.ReadLine());
            queue.Enqueue(N);

            var S = N;

            for (int i = 0, skipCount = 0; i < 49; i++)
            {
                switch(i % 3)
                {
                    case 0:
                        S = queue.ToArray().Skip(skipCount).Take(1).ToArray()[0];
                        queue.Enqueue(S + 1);
                        skipCount++;
                        break;
                    case 1:
                        queue.Enqueue((2 * S + 1));
                        break;
                    case 2:
                        queue.Enqueue(S + 2);
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", queue));
        }
    }
}
