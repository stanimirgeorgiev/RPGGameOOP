using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drugs
{
    public class Aspirin : Drug
    {
        private const int AspirinHealthPoints = 20;

        public Aspirin(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity, AspirinHealthPoints)
        {
        }
    }
}
