using System;
using BulgarianReality.Humans;
using BulgarianReality.Interfaces;

namespace BulgarianReality.Items.Accounts
{
    public class DepositAccount : Account, IWithDraw
    {
        public DepositAccount(string iban, Human owner, decimal balance) 
            : base(iban, owner, balance)
        {
        }

        public void WithDraw(decimal money)
        {
            if (this.Balance < money)
            {
                throw new ArgumentException("Sorry. You don't have enough money in your account.");
            }
            this.Balance -= money;
        }
    }
}
