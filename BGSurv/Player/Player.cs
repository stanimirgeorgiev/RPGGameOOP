using System.Data.Common;
using System.Drawing;
using BGSurv.Config;


namespace BGSurv.Player
{

    using Map;
    public class Player
    {
        public Player(Game.Location location)
        {
            this.Location = location;
        }

        public Game.Location Location{ get; set; }

        void KillMonsterInList(Human m1)
        {
            foreach (var m in Game.Instance().worldMapMonsters)
            {
                if (m == m1)
                {
                    m.alive = false;
                }
            }
        } 
    }
}