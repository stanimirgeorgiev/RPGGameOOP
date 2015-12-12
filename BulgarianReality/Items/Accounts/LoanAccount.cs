using BulgarianReality.Humans;

namespace BulgarianReality.Items.Accounts
{
    public class LoanAccount : Account
    {
        public LoanAccount(string iban, Human owner, decimal balance) 
            : base(iban, owner, balance)
        {
        }
    }
}
