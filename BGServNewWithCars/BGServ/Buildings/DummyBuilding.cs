
using System.Drawing;

namespace BulgarianReality.Buildings
{
    public class DummyBuilding : Building
    {
        private Image image = new Bitmap(@"images\DummyTile.png");

        public Image Image
        {
            get { return this.Image; }
            set { this.Image = value; }
        }
    }
}
