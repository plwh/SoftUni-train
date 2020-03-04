using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyBilliard
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] delimitedChars = new char[] { '-', ',' };
            Dictionary<string, decimal> shop = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] entityInput = Console.ReadLine().Split('-');

                string entityName = entityInput[0];
                decimal entityPrice = decimal.Parse(entityInput[1]);

                if (!shop.ContainsKey(entityInput[0]))
                {
                    shop.Add(entityName, entityPrice);
                }
                else
                {
                    shop[entityName] = entityPrice;
                }
            }

            List<Customer> customers = new List<Customer>();

            string line = Console.ReadLine();

            while (line != "end of clients")
            {
                string[] customerInfo = line.Split(delimitedChars);

                string custName = customerInfo[0];
                string custItem = customerInfo[1];
                int custItemQuantity = int.Parse(customerInfo[2]);

                if (shop.ContainsKey(custItem))
                {
                    var custShopList = new Dictionary<string, int>();
                    custShopList.Add(custItem, custItemQuantity);
                    decimal custBill = shop[custItem] * custItemQuantity;

                    var customer = new Customer(custName, custShopList, custBill);

                    if (customers.Any(x => x.Name == custName))
                    {
                        var currCust = customers.First(x => x.Name == custName);

                        if (currCust.ShopList.ContainsKey(custItem))
                        {
                            currCust.ShopList[custItem] += custItemQuantity;

                            currCust.Bill += shop[custItem] * custItemQuantity;
                        }
                        else
                        {
                            currCust.ShopList[custItem] = custItemQuantity;

                            currCust.Bill += shop[custItem] * custItemQuantity;
                        }
                    }
                    else
                    {
                        customers.Add(customer);
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var customer in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine("{0}", customer.Name);
                foreach (var pair in customer.ShopList)
                {
                    Console.WriteLine("-- {0} - {1}", pair.Key, pair.Value);
                }
                Console.WriteLine("Bill: {0:F2}", customer.Bill);
            }
            Console.WriteLine("Total bill: {0:F2}",customers.Sum(x => x.Bill));
        }

        class Customer
        {
            public Customer(string name, Dictionary<string, int> shopList, decimal bill)
            {
                Name = name;
                ShopList = shopList;
                Bill = bill;
            }

            public string Name { get; set; }
            public Dictionary<string, int> ShopList { get; set; }
            public decimal Bill { get; set; }
        }
    }
}
