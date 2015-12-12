using BulgarianReality.Humans;
using BulgarianReality.Items.Weapons;

namespace BulgarianReality.Interfaces
{
    public interface IAttack
    {
        void Attack(Human target, Weapon weapon);
    }
}
