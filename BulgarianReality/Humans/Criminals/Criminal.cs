using BulgarianReality.Interfaces;
using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Weapons;

namespace BulgarianReality.Humans.Criminals
{
    using System.Drawing;

    using Enums;

    public abstract class Criminal : Human, IAttack
    {
        protected Criminal(int id, string firstname, string lastname, int age, Gender gender, int health, int joy, 
            Wallet wallet, Point location, Image image)
            : base(id, firstname, lastname, age, gender, health, joy, wallet, location, image)
        {
        }

        public abstract void Attack(Human target, Weapon weapon);
    }
}
