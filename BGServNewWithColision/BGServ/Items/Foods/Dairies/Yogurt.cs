using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Dairies
{
    public class Yogurt : Dairy
    {
        public Yogurt(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
