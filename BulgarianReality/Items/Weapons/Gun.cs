using BulgarianReality.Humans;

namespace BulgarianReality.Items.Weapons
{
    public class Gun : Weapon
    {
        private const int GunDamage = 40;

        public Gun(string name, Human owner, decimal price, int quantity) 
            : base(name, owner, price, quantity, GunDamage)
        {
        }
    }
}
