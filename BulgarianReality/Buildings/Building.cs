using System.Drawing;

namespace BulgarianReality.Buildings
{
    public abstract class Building
    {
        private Point location;
        private Image image;
        private int id;

        protected Building(int id, Image image, Point location)
        {
            this.Id = id;
            this.Image = image;
            this.Location = location;
        }

        public Point Location { get; set; }

        public Image Image { get; set; }

        public int Id { get; set; }
    }
}
