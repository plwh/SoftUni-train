using System;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //using (var db = new BillsPaymentSystemContext())
            //{
            //    // db.Database.Migrate();
            //    db.Database.EnsureCreated();
            //    Seed(db);
            //}

            Console.Write("Please enter user ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Please enter bill amount:");
            decimal billAmount = decimal.Parse(Console.ReadLine());

            PayBills(userId, billAmount);
        }

        private static void Seed(BillsPaymentSystemContext db)
        {
            using (db)
            {
                var user = new User()
                {
                    FirstName = "Pesho",
                    LastName = "Stamatov",
                    Email = "pesho@abv.bg",
                    Password = "azsympesho"
                };

                var creditCards = new CreditCard[]
                {
                    new CreditCard(DateTime.ParseExact("20.05.2020", "dd.mm.yyyy", null), 1000m, 5m),
                    new CreditCard(DateTime.ParseExact("20.05.2020", "dd.mm.yyyy", null), 400m, 200m)
                };

                var bankAccount = new BankAccount(1500m, "Swiss Bank", "SWSSBANK");

                var paymentMethods = new PaymentMethod[]
                {
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCards[0],
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        CreditCard = creditCards[1],
                        Type = PaymentMethodType.CreditCard
                    },
                    new PaymentMethod()
                    {
                        User = user,
                        BankAccount = bankAccount,
                        Type = PaymentMethodType.BankAccount
                    }
                };

                db.Users.Add(user);
                db.CreditCards.AddRange(creditCards);
                db.BankAccounts.Add(bankAccount);
                db.PaymentMethods.AddRange(paymentMethods);
                db.SaveChanges();
            }
        }

        private static void PayBills(int userId, decimal billAmount)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                try
                {
                    var bankAccounts = db.PaymentMethods
                        .Include(pm => pm.BankAccount)
                        .Where(pm => pm.UserId == userId && pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .ToList();

                    var cards = db.PaymentMethods
                        .Include(pm => pm.CreditCard)
                        .Where(pm => pm.UserId == userId && pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .ToList();

                    var moneyAvailable = bankAccounts.Select(ba => ba.Balance).Sum() + cards.Select(cc => cc.LimitLeft).Sum();

                    if (moneyAvailable < billAmount)
                    {
                        throw new Exception("Insufficient Funds");
                    }

                    foreach (var acc in bankAccounts)
                    {
                        if (billAmount == 0 || acc.Balance == 0)
                        {
                            continue;
                        }

                        decimal moneyInAccount = acc.Balance;
                        if (moneyInAccount < billAmount)
                        {
                            acc.Withdraw(moneyInAccount);
                            billAmount -= moneyInAccount;
                        }
                        else
                        {
                            acc.Withdraw(billAmount);
                            billAmount -= billAmount;
                        }
                    }

                    foreach (var creditCard in cards)
                    {
                        if (billAmount == 0 || creditCard.LimitLeft == 0)
                        {
                            continue;
                        }

                        decimal limitLeft = creditCard.LimitLeft;
                        if (limitLeft < billAmount)
                        {
                            creditCard.Withdraw(limitLeft);
                            billAmount -= limitLeft;
                        }
                        else
                        {
                            creditCard.Withdraw(billAmount);
                            billAmount -= billAmount;
                        }
                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
