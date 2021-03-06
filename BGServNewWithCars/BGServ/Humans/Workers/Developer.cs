﻿using BulgarianReality.Items.Belongings;

namespace BulgarianReality.Humans.Workers
{
    using System.Drawing;

    using Enums;

    public class Developer : Worker
    {
        private const int DaySalary = 100;

        private const int WorkerHealth = 200;
        private const int WorkerJoy = 50;

        private const int ID = 1;

        public Developer(int id,string firstname, string lastname, int age, Gender gender, 
            Wallet wallet, Point location, Image[] image)
            : base(id, firstname, lastname, age, gender, WorkerHealth, WorkerJoy, wallet, location, image)
        {
        }

        public override void Work()
        {
            this.Wallet.Balance += DaySalary;
        }   
    }
}
