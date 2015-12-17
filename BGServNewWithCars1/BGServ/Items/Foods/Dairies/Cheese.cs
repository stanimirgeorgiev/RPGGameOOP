using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Dairies
{
    public class Cheese : Dairy
    {
        public Cheese(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
