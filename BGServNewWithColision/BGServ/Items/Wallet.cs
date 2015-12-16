using System;
using BulgarianReality.Humans;

namespace BulgarianReality.Items.Belongings
{
    public class Wallet
    {
        private decimal balance;

        public Wallet(decimal balance)
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
