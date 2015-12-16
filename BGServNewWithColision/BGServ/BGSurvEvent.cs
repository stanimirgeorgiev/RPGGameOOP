using BulgarianReality.Humans;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGServ
{
    public class BGSurvEvent
    {
        private Human player;
        private Designer designer;

        public BGSurvEvent()
        {
            this.player = Game.Instance.Player;
        }

        public void HandleKeyPress(KeyEventArgs e)
        {
            Point nextPont = new Point(0, 0);

            if (!Game.Instance.Player.InAction)
            {
                if (e.KeyCode == Keys.Left)
                {
                    nextPont = new Point(this.player.Location.X - 40, this.player.Location.Y);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(-40, 0);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / 40][Game.Instance.Player.Location.X / 40].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / 40][(Game.Instance.Player.Location.X / 40) + 1].PlayerId = 0;
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    nextPont = new Point(this.player.Location.X + 40, this.player.Location.Y);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(40, 0);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / 40][Game.Instance.Player.Location.X / 40].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / 40][(Game.Instance.Player.Location.X / 40) - 1].PlayerId = 0;

                    }
                }
                if (e.KeyCode == Keys.Up)
                {
                    nextPont = new Point(this.player.Location.X, this.player.Location.Y - 40);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(0, -40);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / 40][Game.Instance.Player.Location.X / 40].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[(Game.Instance.Player.Location.Y / 40) + 10][(Game.Instance.Player.Location.X / 40)].PlayerId = 0;
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    nextPont = new Point(this.player.Location.X, this.player.Location.Y + 40);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(0, 40);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / 40][Game.Instance.Player.Location.X / 40].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[(Game.Instance.Player.Location.Y / 40) - 1][(Game.Instance.Player.Location.X / 40)].PlayerId = 0;
                    }
                }
            }
            //designer.DrawPlayer(this.player);
            Game.Instance.Designer.DrawMap(Map.Instance.CurrentMap(this.player));
            Game.Instance.Designer.DrawBots(this.player, Map.Instance.CurrentMap(this.player), Game.Instance.Bots);
            Game.Instance.Designer.DrawPlayer(this.player);

        }

        private bool CheckIsWalkable(Point check)
        {
            if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Walkable)
            {
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].PlayerId > 1)
                {
                    Game.Instance.Player.Health += 10;
                    Game.Instance.Player.InAction = true;
                    
                    return false;
                }
                
                return true;
            }
            return false;
        }
        private bool DetectColisionWithBuilding(Point check)
        {
            if(Map.Instance.WorldMap[check.Y / 40][check.X / 40].Walkable)
            {
                return true;
            }
            return false;
        }

    }
}
