using System.Collections.Generic;
using BulgarianReality.Items.Accounts;

namespace BulgarianReality.Buildings
{
    using System.Drawing;

    public class Bank : Building
    { 
        private readonly IList<Account> accounts;

        public Bank(int id, Image image, Point location)
            : base(id, image, location)
        {
            this.accounts = new List<Account>();
        }

        public IEnumerable<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        public void Add(Account account)
        {
            this.accounts.Add(account);
        }
    }
}
