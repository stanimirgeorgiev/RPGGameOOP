using System.Drawing;
using BulgarianReality.Interfaces;

namespace BulgarianReality.Transportation
{
    public abstract class Transport : IMovable
    {
    private Point location;
        public Point Location { get; set; }
        public void Move(int x, int y)
        {
            this.location.X += x; 
            this.location.Y += y; 
        }
    }
}
