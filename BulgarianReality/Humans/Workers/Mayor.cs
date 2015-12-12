namespace BulgarianReality.Humans.Workers
{
    using System.Drawing;

    using Enums;

    using Interfaces;

    using Items.Belongings;

    public class Mayor : Worker, ICorruptable
    {
        private const decimal DaySalary = 150;
        private const int ID = 3;

        public Mayor(string firstname, string lastname, int age, Gender gender, int health, int joy, 
            Wallet wallet, Point location, Image image)
            : base(ID, firstname, lastname, age, gender, health, joy, wallet, location, image)
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
