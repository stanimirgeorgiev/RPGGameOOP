using System.Drawing;

namespace BGSurv
{
    public class CombatPartyMember
    {
        //
        public string name;

        public int health;
        public int attackPower;
        public Image img;

        //

        public CombatPartyMember(int health, int attackPower, Image img, string name)
        {
            this.health = health;
            this.attackPower = attackPower;
            this.img = img;
            this.name = name;
        }
    }
}