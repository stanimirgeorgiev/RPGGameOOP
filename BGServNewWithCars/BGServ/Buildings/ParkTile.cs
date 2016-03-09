using System.Drawing;

namespace BulgarianReality.Buildings
{
    public class ParkTile : MapTile
    {
        public ParkTile()
        {
            this.Walkable = true;
            this.Image = new Bitmap(@"images\GrassTile.png");
        }
    }
}