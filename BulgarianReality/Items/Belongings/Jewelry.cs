using BulgarianReality.Humans;

namespace BulgarianReality.Items.Belongings
{
    public class Jewelry : Item
    {
        public Jewelry(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity)
        {
        }
    }
}
