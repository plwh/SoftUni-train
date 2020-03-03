using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var intelValue = int.Parse(Console.ReadLine());
            var shotBullets = 0;
            var bulletsUsed = 0;
 
            while(bullets.Count > 0 && locks.Count > 0)
            {
                var currBullet = bullets.Pop();
                var currLock = locks.Peek();
                bulletsUsed++;

                if (currLock >= currBullet)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (++shotBullets == barrelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    shotBullets = 0;
                }
            }

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelValue - bulletsUsed * bulletPrice}");
            }
        }
    }
}
