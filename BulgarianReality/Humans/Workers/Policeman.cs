using BulgarianReality.Interfaces;
using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Weapons;

namespace BulgarianReality.Humans.Workers
{
    using System.Drawing;

    using Enums;

    public class Policeman : Worker, ICorruptable, IAttack
    {
        private const int DaySalary = 30;
        private const int PolicemanHealth = 90;
        private const int PolicemanJoy = 100;

        private const int ID = 4;

        public Policeman(string firstname, string lastname, int age, Gender gender,
            Wallet wallet, Point location, Image image)
            : base(ID, firstname, lastname, age, gender, PolicemanHealth, PolicemanJoy, wallet, location, image)
        {
        }

        public override void Work()
        {
            this.Wallet.Balance += DaySalary;
        }

        public void Bribe(decimal money)
        {
            this.Wallet.Balance += money;
        }

        public void Attack(Human target, Weapon weapon)
        {
            target.Health -= weapon.Damage;
        }
    }
}
