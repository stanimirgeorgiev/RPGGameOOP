using System.Drawing;
using BulgarianReality.Interfaces;

namespace BulgarianReality.Transportation
{
    public abstract class Transport : IMovable
    {
        private Point location;
        private int id;
        private Image image;

        public Transport()
            : this(0, new Point(0, 0))
        {
        }
        public Transport(int id, Point location)
        {
        }

        public int Id { get; set; }

        public Image Image { get; set; }
        public Point Location { get { return this.location; } set { this.location = value; } }
        public Image[] DirectionImage { get; set; }
        public bool InAction { get; set; }
        public int Direction { get; set; }
        public void Move(int x, int y)
        {
            this.location.X += x;
            this.location.Y += y;
        }
    }
}
