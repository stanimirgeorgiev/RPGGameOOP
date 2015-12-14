using BulgarianReality.Humans;

namespace BulgarianReality.Items.Weapons
{
    public class MachineGun : Weapon
    {
        public MachineGun(string name, Human owner, decimal price, int quantity, int damage) 
            : base(name, owner, price, quantity, damage)
        {
        }
    }
}
