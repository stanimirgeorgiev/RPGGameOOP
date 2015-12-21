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

        public Rapist(int id,string firstname, string lastname, int age, Gender gender,
            Wallet wallet, Point location, Image[] image)
            : base(id, firstname, lastname, age, gender, RapistHealth, RapistJoy, wallet, location, image)
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
