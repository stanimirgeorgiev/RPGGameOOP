﻿using System.Collections.Generic;
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
    using BulgarianReality.Exceptions;

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
        //private bool inAction = false;



        protected Human()
            : this(0, "", "", 0, Gender.Male, 0, 0, new Wallet(0), new Point(0, 0), new Image[4])
        {

        }
        protected Human(int id, string firstname, string lastname, int age, Gender gender, int health, int joy,
            Wallet wallet, Point location, Image[] image)
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
            this.ImageDirection = image;
            this.Items = new List<Item>();
            this.Accounts = new List<Account>();
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Health 
        {
            get { return this.health; }
            set 
            {
                if(value <0)
                {
                    throw new InsufficientHealthException("You'r dead. Game over.");
                }
                this.health = value;
            }
        }

        public int Joy { get; set; }

        public Wallet Wallet { get; set; }

        public IList<Item> Items { get; set; }

        public IList<Account> Accounts { get; set; }

        public Image Image { get; set; }
        public Image[] ImageDirection { get; set; }
        public Point Location { get { return this.location; } set { this.location = value; } }
        public int Direction { get; set; }

        public bool InAction { get; set; }
        public string CollisionImage { get; set; }
        public Human Oponent { get; set; }
        public string BuilDingName { get; set; }

        public string MeetMsg  { get; set; }
        //public bool InActionWithBuilding { get; set; }
       // public string BuildingImage { get; set; }
       // public string BuildingName { get; set; }

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
