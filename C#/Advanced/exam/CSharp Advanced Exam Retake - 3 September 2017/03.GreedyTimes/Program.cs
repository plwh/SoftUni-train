using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GreedyTimes
{
    class Program
    {
        static Dictionary<string, Dictionary<string, long>> bag = new Dictionary<string, Dictionary<string, long>>();

        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            var goods = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            long totalGoodsAmount = 0;
            long totalGoldAmount = 0;
            long totalGemAmount = 0;
            long totalCashAmount = 0;

            for (int i = 0; i < goods.Length - 1; i += 2)
            {
                var currItem = goods[i];
                var amountToAdd = int.Parse(goods[i + 1]);

                if (totalGoodsAmount + amountToAdd > bagCapacity)
                    continue;

                if (currItem.Length == 3) // we have cash
                {
                    totalCashAmount += amountToAdd;

                    if (totalCashAmount <= totalGemAmount)
                    {
                        AddGoods("Cash", currItem, amountToAdd);
                        totalGoodsAmount += amountToAdd;
                    }
                    else
                    {
                        totalCashAmount -= amountToAdd;
                    }
                }
                else if (currItem.ToLower().EndsWith("gem") && currItem.Length >= 4) // we have gem
                {
                    totalGemAmount += amountToAdd;

                    if (totalGoldAmount >= totalGemAmount)
                    {
                        AddGoods("Gem", currItem, amountToAdd);
                        totalGoodsAmount += amountToAdd;
                    }
                    else
                    {
                        totalGemAmount -= amountToAdd;
                    }
                }
                else if (currItem.ToLower() == "gold") // we have gold
                {
                    totalGoldAmount += amountToAdd;

                    AddGoods("Gold", currItem, amountToAdd);
                    totalGoodsAmount += amountToAdd;
                }
            }

            foreach (var pairs in bag.OrderByDescending(a => a.Value.Values.Sum()))
            {
                Console.WriteLine($"<{pairs.Key}> ${pairs.Value.Values.Sum()}");
                foreach (var item in pairs.Value.OrderByDescending(a => a.Key).ThenByDescending(a => a.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void AddGoods(string type, string currItem, int itemAmount)
        {
            if (!bag.ContainsKey(type))
            {
                bag[type] = new Dictionary<string, long>();
            }

            if (!bag[type].ContainsKey(currItem))
            {
                bag[type].Add(currItem, itemAmount);
            }
            else
            {
                bag[type][currItem] += itemAmount;
            }
        }
    }
}