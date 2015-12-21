using System;
using System.Collections.Generic;
using System.Linq;
using BulgarianReality.Interfaces;
using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Drugs;

namespace BulgarianReality.Humans.Workers
{
    using System.Drawing;

    using BulgarianReality.Enums;

    public class Doctor : Worker, ICorruptable, IHealable
    {
        private const decimal DaySalary = 50;
        private const int DoctorHealth = 100;
        private const int DoctorJoy = 20;
        private const int ID = 2;

        private readonly IList<Drug> drugs;

        public Doctor(int id,string firstname, string lastname, int age, Gender gender, 
            Wallet wallet, Point location, Image[] image)
            : base(id, firstname, lastname, age, gender, DoctorHealth, DoctorJoy, wallet, location, image)
        {
            this.drugs = new List<Drug>();
        }

        public IEnumerable<Drug> Drugs
        {
            get
            {
                return this.drugs;
            }
        }

        private void Remove(Drug drug)
        {
            this.drugs.Remove(drug);
        }

        public override void Work()
        {
            this.Wallet.Balance += DaySalary;
        }

        public void Bribe(decimal money)
        {
            this.Wallet.Balance += money;
        }

        public void Heal(Human person, Drug drug)
        {
            var currentDrug = this.drugs.FirstOrDefault(d => d.Name == drug.Name);

            if (currentDrug != null)
            {
                person.Health += currentDrug.HealthPoints;
                this.drugs.Remove(drug);
            }
            else
            {
                Console.WriteLine("Sorry. I don't have this drug.");
            }
           
        }
    }
}
