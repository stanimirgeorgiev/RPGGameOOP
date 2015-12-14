using System.Drawing;
using BGSurv.Map;

namespace BGSurv
{
    public class Human : WorldMapSprite
    {
        public bool isStatic;
        public bool alive;
        public CombatPartyMember member;
        public Human(Point location, Image image, int ID, CombatPartyMember member)
            : base(location, image, ID)
        {
            this.Location = location;
            this.member = member;
            isStatic = true;
            alive = true;
            this.InAction = false;

        }

        public bool InAction { get; set; }
        public Point Location { get; set; }
    }
}
