using BulgarianReality.Humans;

namespace BulgarianReality.Items.Weapons
{
    public class Knife : Weapon
    {
        public Knife(string name, Human owner, decimal price, int quantity, int damage) 
            : base(name, owner, price, quantity, damage)
        {
        }
    }
}
