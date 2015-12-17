using System;
using System.Collections.Generic;
using System.Drawing;
using BulgarianReality.Enums;
using BulgarianReality.Items.Accounts;
using BulgarianReality.Items.Belongings;
using BulgarianReality.Items.Drinks;
using BulgarianReality.Items.Foods;

namespace BulgarianReality.Transportation
{
    public class Car : Transport
    {
        private int id;
        private Point location;
        private Image image;
        private int direction;
        //private bool inAction = false;
        private Random rand = new Random();
        public Car(int id, Point location, Image[] directionImage)
        {
            this.Id = id;
            this.Location = location;
            this.DirectionImage = directionImage;
            this.Direction = rand.Next(0, 4);
            this.Image = directionImage[this.Direction];
        }
    }
}
