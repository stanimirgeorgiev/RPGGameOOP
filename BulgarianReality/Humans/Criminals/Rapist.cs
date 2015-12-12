using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Weapons;

namespace BulgarianReality.Humans.Criminals
{
    using System.Drawing;

    using Enums;
    using Interfaces;

    public class Rapist : Criminal, IAttack
    {
        private const int RapistHealth = 60;
        private const int RapistJoy = 5;

        private const int ID = 6;

        public Rapist(string firstname, string lastname, int age, Gender gender, int health, int joy,
            Wallet wallet, Point location, Image image)
            : base(ID, firstname, lastname, age, gender, health, joy, wallet, location, image)
        {
        }

        public override void Attack(Human target, Weapon weapon)
        {
            this.Joy += target.Joy;
            target.Joy = 0;
            this.Wallet.Balance += target.Wallet.Balance;
            target.Wallet.Balance = 0;
        }
    }
}
