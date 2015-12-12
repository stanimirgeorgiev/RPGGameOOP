using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drinks.Beverages
{
    public class RedBull : Beverage
    {
        public RedBull(string name, Human owner, decimal price, int quantity, int joyPoints) 
            : base(name, owner, price, quantity, joyPoints)
        {
        }
    }
}
