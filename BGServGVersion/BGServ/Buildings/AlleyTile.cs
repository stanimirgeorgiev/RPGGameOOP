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
    class AlleyTile : Building
    {
        public AlleyTile()
        {
            this.Walkable = true;
            this.Image = new Bitmap(@"images\AlleyTile.png");
        }
    }
}
