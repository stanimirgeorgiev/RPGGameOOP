using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drugs
{
    public abstract class Drug : Item
    {
        private int healthPoints;

        protected Drug(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity)
        {
            this.HealthPoints = healthPoints;
        }

        public int HealthPoints { get; set; }
    }
}
