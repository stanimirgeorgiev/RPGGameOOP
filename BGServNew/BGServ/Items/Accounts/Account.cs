using System;
using BulgarianReality.Humans;
using BulgarianReality.Interfaces;

namespace BulgarianReality.Items.Accounts
{
    public abstract class Account : IDeposit
    {
        private string iban;
        private Human owner;
        private decimal balance;

        protected Account(string iban, Human owner, decimal balance)
        {
            this.Iban = iban;
            this.Owner = owner;
            this.Balance = balance;
        }

        public string Iban
        {
            get { return this.iban; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 18)
                {
                    throw new ArgumentNullException("IBAN should be exactly 18 characters long.");
                }

                this.iban = value;
            }
        }

        public Human Owner { get; private set; }

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

        public virtual void Deposit(decimal money)
        {
            this.Balance += money;
        }
    }
}
