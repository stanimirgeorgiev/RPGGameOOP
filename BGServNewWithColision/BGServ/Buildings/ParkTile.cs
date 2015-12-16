using System.Drawing;

namespace BulgarianReality.Buildings
{
    public class ParkTile : Building
    {
        public ParkTile()
        {
            this.Walkable = true;
            this.Image = new Bitmap(@"images\GrassTile.png");
        }
    }
}