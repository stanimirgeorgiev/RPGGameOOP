using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Meats
{
    public abstract class Meat : Food
    {
        protected Meat(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
