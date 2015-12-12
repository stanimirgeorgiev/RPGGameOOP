using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Meats
{
    public class Beaf : Meat
    {
        public Beaf(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
