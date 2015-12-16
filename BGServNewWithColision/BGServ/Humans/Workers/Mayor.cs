namespace BulgarianReality.Humans.Workers
{
    using System.Drawing;

    using Enums;

    using Interfaces;

    using Items.Belongings;

    public class Mayor : Worker, ICorruptable
    {
        private const decimal DaySalary = 150;
        private const int MayorHealth = 90;
        private const int MayorJoy = 100;
        private const int ID = 3;

        public Mayor(int id,string firstname, string lastname, int age, Gender gender, 
            Wallet wallet, Point location, Image image)
            : base(id, firstname, lastname, age, gender, MayorHealth, MayorJoy, wallet, location, image)
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
    }
}
