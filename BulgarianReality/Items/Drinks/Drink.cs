using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drinks
{
    public abstract class Drink : Item
    {
        private int joyPoints;

        protected Drink(string name, Human owner, decimal price, int quantity, int joyPoints) 
            : base(name, owner, price, quantity)
        {
            this.JoyPoints = joyPoints;
        }

        public int JoyPoints { get; set; }
    }
}
