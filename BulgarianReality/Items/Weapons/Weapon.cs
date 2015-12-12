using BulgarianReality.Humans;

namespace BulgarianReality.Items.Weapons
{
    public abstract class Weapon : Item
    {
        private int damage;

        protected Weapon(string name, Human owner, decimal price, int quantity, int damage) 
            : base(name, owner, price, quantity)
        {
            this.Damage = damage;
        }

        public int Damage { get; set; }
    }
}
