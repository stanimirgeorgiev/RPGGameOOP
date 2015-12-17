using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BulgarianReality.Buildings;

namespace BulgarianReality.Buildings
{
    class StreetTile : Building
    {
        public StreetTile(Boolean walkable)
        {
            this.Walkable = walkable;
            if (walkable)
            {
                this.Image = new Bitmap(@"images\ZebraTile.png");
            }
            else
            {
                this.Image = new Bitmap(@"images\StreetTile.png");
            }
        }
    }
}
