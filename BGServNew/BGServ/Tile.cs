﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgarianReality.Buildings;
using BulgarianReality.Humans;

namespace WindowsFormsApplication1
{
    public class Tile
    {

        public Tile(Point point, Image image, Human player, Building building, bool walkable)
        //public Tile()

        {
            this.Location = point;
            this.Image = image;
            this.Player = player;
            this.Building = building;
            this.Walkable = walkable;

        }

        public Point Location { get; set; }
        public Image Image { get; set; }
        public Human Player { get; set; }
        public Building Building { get; set; }
        public bool Walkable { get; set; }
    }
}