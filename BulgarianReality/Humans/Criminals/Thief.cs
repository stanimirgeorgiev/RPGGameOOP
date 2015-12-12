using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Weapons;

namespace BulgarianReality.Humans.Criminals
{
    using System.Collections.Generic;
    using System.Drawing;

    using Workers;
    using Interfaces;
    using Items;

    using Enums;

    public class Thief : Criminal, IStealable
    {
        private const int ThiefHealth = 70;
        private const int ThiefJoy = 65;

        private const int ID = 7;

        public Thief(string firstname, string lastname, int age, Gender gender,
            Wallet wallet, Point location, Image image)
            : base(ID, firstname, lastname, age, gender, ThiefHealth, ThiefJoy, wallet, location, image)
        {
        }

        public override void Attack(Human target, Weapon weapon)
        {
            target.Health -= weapon.Damage;
        }

        public void Steal(Worker worker, IList<Item> items)
        {
            decimal sum = 0;

            foreach (var item in items)
            {
                sum += item.Price;
            }

            this.Wallet.Balance += sum;
            this.Wallet.Balance += worker.Wallet.Balance;

            worker.Wallet.Balance = 0;

            //var weapon = new Gun("Glog", worker, 30, 1);

            //worker.Items.Add(weapon);
        }
    }
}
