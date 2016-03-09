using System.Drawing;

namespace BulgarianReality.Buildings
{
    public abstract class MapTile
    {
        private Point location;
        private Image image;
        private int id;

        protected MapTile() : this(0,new Bitmap(@"images\DummyTile.png"),new Point(0,0))
        {
        }
        protected MapTile(int id, Image image, Point location)
        {
            this.Id = id;
            this.Image = image;
            this.Location = location;
        }

        public Point Location { get; set; }

        public Image Image { get; set; }

        public int Id { get; set; }
        public bool Walkable { get; set; }
    }
}
