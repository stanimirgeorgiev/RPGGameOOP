using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drugs
{
    public class VitaminC : Drug
    {
        private const int VitaminCHealthPoints = 30;

        public VitaminC(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity, VitaminCHealthPoints)
        {
        }
    }
}
