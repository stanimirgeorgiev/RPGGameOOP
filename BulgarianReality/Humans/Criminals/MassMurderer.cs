using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Weapons;

namespace BulgarianReality.Humans.Criminals
{
    using System.Drawing;

    using BulgarianReality.Enums;

    public class MassMurderer : Criminal
    {
        private const int ID = 5;

        public MassMurderer(string firstname, string lastname, int age, Gender gender, int health, int joy, 
            Wallet wallet, Point location, Image image)
            : base(ID, firstname, lastname, age, gender, health, joy, wallet, location, image)
        {
        }

        public override void Attack(Human target, Weapon weapon)
        {
            throw new System.NotImplementedException();
        }
    }
}
