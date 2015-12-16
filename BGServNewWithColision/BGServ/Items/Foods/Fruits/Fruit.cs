using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Fruits
{
    public abstract class Fruit : Food
    {
        protected Fruit(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
