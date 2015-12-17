using BulgarianReality.Humans;

namespace BulgarianReality.Items.Belongings
{
    public class Laptop : Item
    {
        public Laptop(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity)
        {
        }
    }
}
