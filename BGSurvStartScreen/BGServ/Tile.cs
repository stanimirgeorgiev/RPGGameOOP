using System;
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

        public Tile(Point point, int playerId, Building building, bool walkable, bool isStreet)
        //public Tile()

        {
            this.Location = point;
            this.PlayerId = playerId;
            this.Building = building;
            this.Walkable = walkable;
            this.IsStreet = isStreet;

        }

        public Point Location { get; set; }
        public int PlayerId { get; set; }
        public Building Building { get; set; }
        public bool Walkable { get; set; }
        public bool IsStreet { get; set; }
    }
}
