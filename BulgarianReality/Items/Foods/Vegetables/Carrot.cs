using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Vegetables
{
    public class Carrot : Vegetable
    {
        public Carrot(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
