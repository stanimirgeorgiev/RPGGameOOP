using System.Drawing;
using System.Windows.Forms;
using BGSurv.Map;

namespace BGSurv.Events
{
    public class HandleKey
    {
        public void HandleKeyPress(KeyEventArgs e)
        {
            //Determine if player can move
            if (!Game.Instance().Character.InAction)
            {
                TextBoxReader reader = new TextBoxReader();
                //
                if (reader.open)
                {
                    if (e.KeyCode == Keys.Enter){reader.Next();}

                    if (reader.instructions.Count > 0)
                    {
                        Instructions instr = new Instructions();
                        instr.ExectueInstruction(reader.instructions);
                    }
                }
                else
                {
                    //
                    Point p = new Point(0, 0);

                    if (e.KeyCode == Keys.Left)
                    {
                        p = new Point(-40, 0);
                    }
                    if (e.KeyCode == Keys.Right)
                    {
                        p = new Point(40, 0);
                    }
                    if (e.KeyCode == Keys.Up)
                    {
                        p = new Point(0, -40);
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        p = new Point(0, 40);
                    }

                    //
                    Point potentialMove = new Point(p.X + Game.Instance().PlayerParty.partySprite.location.X,
                        p.Y + Game.Instance().PlayerParty.partySprite.location.Y);


                    if (WorldMap.Instance().GetWalkableAt(potentialMove))
                    {
                        Game.Instance().PlayerParty.partySprite.Move(p.X, p.Y);
                    }
                    else
                    {
                        //Load new map if possible
                        if (potentialMove.X > 40*9)
                        {
                            WorldMap.Instance().LoadNewMap(1, 0, Game.Instance().PlayerHuman);
                            Game.Instance().PlayerParty.partySprite.Move(-360, 0);
                        }
                        if (potentialMove.X < 0)
                        {
                            WorldMap.Instance().LoadNewMap(-1, 0, Game.Instance().PlayerHuman);
                            Game.Instance().PlayerParty.partySprite.Move(360, 0);
                        }
                        if (potentialMove.Y < 0)
                        {
                            WorldMap.Instance().LoadNewMap(0, -1, Game.Instance().PlayerHuman);
                            Game.Instance().PlayerParty.partySprite.Move(0, 360);
                        }
                        if (potentialMove.Y > 40*8)
                        {
                            WorldMap.Instance().LoadNewMap(0, 1, Game.Instance().PlayerHuman);
                            Game.Instance().PlayerParty.partySprite.Move(0, -320);
                        }
                    }
                }

            }
            else
            {
                //Use monsterInCombat variable to remove correct sprite
                //If the combat GUI has exited combat, remove our enemy sprite
                //if (!combatGUI.InCombat)
                //{
                //    monsterInCombat.alive = false;
                //    KillMonsterInList(monsterInCombat);
                //}
                    Game.Instance().Character.InAction = false;
            }
            Colisions col = new Colisions();
            col.DetectCollision();
            Draw.Instance().Render();
        }
    }
}