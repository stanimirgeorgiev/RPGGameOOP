using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApplication1;
using BulgarianReality.Interfaces;
using BulgarianReality.Items;
using BulgarianReality.Items.Accounts;
using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Drinks;
using BulgarianReality.Items.Foods;
using Account = BulgarianReality.Items.Accounts.Account;
using Wallet = BulgarianReality.Items.Belongings.Wallet;

namespace BulgarianReality.Humans
{
    using System.Drawing;

    using Enums;

    public abstract class Human : IMovable, IDrinkable, IEatable
    {
        private int id;
        private string firstname;
        private string lastname;
        private int age;
        private int health;
        private int joy;
        private Wallet wallet;
        private Point location;
        private Image image;

        protected Human() : this (0, "","", 0, Gender.Male, 0,0,new Wallet(0), new Point(0,0), new Bitmap(@"images/monster.png"))
        {
            
        }
        protected Human(int id, string firstname, string lastname, int age, Gender gender, int health, int joy, 
            Wallet wallet, Point location, Image image)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Gender = gender;
            this.Health = health;
            this.Joy = joy;
            this.Wallet = wallet;
            this.location = location;
            this.Image = image;
            this.Items = new List<Item>();
            this.Accounts = new List<Account>();
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Health { get; set; }

        public int Joy { get; set; }

        public Wallet Wallet { get; set; }

        public IList<Item> Items { get; set; }

        public IList<Account> Accounts { get; set; }

        public Image Image { get; set; }
        public Point Location { get; set; }

        public void Drink(Drink drink)
        {
            this.Joy += drink.JoyPoints;
        }

        public void Eat(Food food)
        {
            this.Health += food.HealthPoints;
        }

        public void Move(int x, int y)
        {
            this.location.X += x;
            this.location.Y += y;
        }
    }
}
