using BGSurv.Map;
using BGSurv.Player;

namespace BGSurv
{
    public class Colisions
    {
        public void DetectCollision()
        {
            foreach (var m in Game.Instance().worldMapMonsters)
            {
                //Check if monster is alive before detecting collision
                if (m.alive && Game.Instance().PlayerParty.partySprite.location == m.location)
                {
                    //Create a reference to monster in combat with
                    var monsterInCombat = m;
                    //combatGUI.StartCombat(playerParty, monsterInCombat.member);
                    
                    //TODO implement game logic for colision detected
                    
                    Game.Instance().Character.InAction = true;
                }
            }
            //foreach (WorldMapSprite m in friendlyNPCs)
            //{
            //    //Check if NPC is alive before detecting collision
            //    if (playerParty.partySprite.location == m.location)
            //    {
            //        playerParty.partySprite.location.X += 40;
            //        if (m.textFilename != "")
            //        {
            //            textBoxReader.OpenText(m.textFilename, m);
            //        }
            //    }
            //}
        } 
    }
}