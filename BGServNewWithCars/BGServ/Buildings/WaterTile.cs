using System.Drawing;

namespace BulgarianReality.Buildings
{
    class WaterTile : MapTile
    {
        public WaterTile()
        {
            this.Walkable = false;
            this.Image = new Bitmap(@"images\WaterTile.png");
        }
    }
}
