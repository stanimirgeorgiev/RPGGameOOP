using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drinks.Beverages
{
    public abstract class Beverage : Drink
    {
        protected Beverage(string name, Human owner, decimal price, int quantity, int joyPoints) 
            : base(name, owner, price, quantity, joyPoints)
        {
        }
    }
}
