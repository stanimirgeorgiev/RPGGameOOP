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
        private Map map;
        private Designer designer;

        public BGSurvEvent(Human player, Designer designer)
        {

            this.designer = designer;
            this.player = player;
            this.map = Map.Instance;
            
        }
       
        public void HandleKeyPress(KeyEventArgs e)
        {
            Point nextPont = new Point(0,0);
            Point move = new Point(0,0);

            if(e.KeyCode == Keys.Left)
            {
                nextPont = new Point(this.player.Location.X - 40, this.player.Location.Y);
                if(this.CheckIsWalkable(nextPont))
                {
                    move = new Point(-40, 0);
                    this.player.Move(move);
                }
                
                
            }
            if (e.KeyCode == Keys.Right)
            {
                nextPont = new Point(this.player.Location.X + 40, this.player.Location.Y);
                if (this.CheckIsWalkable(nextPont))
                {
                    move = new Point(40,0 );
                    this.player.Move(move);
                }
                
            }
            if (e.KeyCode == Keys.Up)
            {
                nextPont = new Point(this.player.Location.X, this.player.Location.Y-40);
                if (this.CheckIsWalkable(nextPont))
                {
                    move = new Point(0, -40);
                    this.player.Move(move);
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                nextPont = new Point(this.player.Location.X, this.player.Location.Y+40);
                if (this.CheckIsWalkable(nextPont))
                {
                    move = new Point(0, 40);
                    this.player.Move(move);
                }
            }
            //designer.DrawPlayer(this.player);
            Game.Instance.Designer.DrawMap(Map.Instance.CurrentMap(player));
            Game.Instance.Designer.DrawBots(player, this.map.CurrentMap(player));
            Game.Instance.Designer.DrawPlayer(this.player);
            
        }
        private bool CheckIsWalkable(Point check)
        {
                if(Map.Instance.WorldMap[check.Y/40][check.X/40].Walkable)
                {
                    return true;
                }
            return false;
        }

    }
}
