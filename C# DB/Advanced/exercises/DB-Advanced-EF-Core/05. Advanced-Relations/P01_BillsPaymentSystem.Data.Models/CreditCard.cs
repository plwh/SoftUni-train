using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public CreditCard() { }

        public CreditCard(DateTime expirattionDate, decimal limit, decimal moneyOwed)
        {
            this.ExpirationDate = expirattionDate;
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
        }

        public int CreditCardId { get; set; }
        public decimal Limit { get; private set; }
        public decimal MoneyOwed { get; private set; }
        public DateTime ExpirationDate { get; set; }

        public decimal LimitLeft => Limit - MoneyOwed;

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (this.LimitLeft < amount || amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid operation");
            }

            this.MoneyOwed -= amount;
        }
    }
}
