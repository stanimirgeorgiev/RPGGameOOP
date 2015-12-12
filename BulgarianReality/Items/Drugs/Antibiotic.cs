using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drugs
{
    public class Antibiotic : Drug
    {
        private const int AntibioticHealthPoints = 50;

        public Antibiotic(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity, AntibioticHealthPoints)
        {
        }
    }
}
