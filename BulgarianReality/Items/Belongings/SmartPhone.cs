using BulgarianReality.Humans;

namespace BulgarianReality.Items.Belongings
{
    public class SmartPhone : Item
    {
        public SmartPhone(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity)
        {
        }
    }
}
