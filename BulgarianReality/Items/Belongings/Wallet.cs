using System;
using BulgarianReality.Humans;

namespace BulgarianReality.Items.Belongings
{
    public class Wallet : Item
    {
        private decimal balance;

        public Wallet(string name, Human owner, decimal price, int quantity, decimal balance) 
            : base(name, owner, price, quantity)
        {
            this.Balance = balance;
        }

        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Balance cannot be negative.");
                }

                this.balance = value;
            }
        }
    }
}
