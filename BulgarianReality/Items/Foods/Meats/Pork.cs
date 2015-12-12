using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Meats
{
    public class Pork : Meat
    {
        public Pork(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
