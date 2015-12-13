using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods
{
    public abstract class Food : Item
    {
        private int healthPoints;

        protected Food(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity)
        {
            this.HealthPoints = healthPoints;
        }

        public int HealthPoints { get; set; }
    }
}
