using BulgarianReality.Humans;
using System;
using System.Collections;
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
        private Collision collision = new Collision();

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
                    nextPont = new Point(this.player.Location.X - Config.GameConfig.TileSize, this.player.Location.Y);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(-Config.GameConfig.TileSize, 0);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][Game.Instance.Player.Location.X / Config.GameConfig.TileSize].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][(Game.Instance.Player.Location.X / Config.GameConfig.TileSize) + 1].PlayerId = 0;
                    }
                    this.collision.DetectColisionWithBuilding(nextPont);
                    this.collision.DetectColisionWithPlayer(nextPont);
                   
                }
                if (e.KeyCode == Keys.Right)
                {
                    nextPont = new Point(this.player.Location.X + Config.GameConfig.TileSize, this.player.Location.Y);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(Config.GameConfig.TileSize, 0);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][Game.Instance.Player.Location.X / Config.GameConfig.TileSize].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][(Game.Instance.Player.Location.X / Config.GameConfig.TileSize) - 1].PlayerId = 0;

                    }
                    this.collision.DetectColisionWithBuilding(nextPont);
                    this.collision.DetectColisionWithPlayer(nextPont);
                    
                }
                if (e.KeyCode == Keys.Up)
                {
                    nextPont = new Point(this.player.Location.X, this.player.Location.Y - Config.GameConfig.TileSize);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(0, -Config.GameConfig.TileSize);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][Game.Instance.Player.Location.X / Config.GameConfig.TileSize].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[(Game.Instance.Player.Location.Y / Config.GameConfig.TileSize) + 1][(Game.Instance.Player.Location.X / Config.GameConfig.TileSize)].PlayerId = 0;
                    }
                    this.collision.DetectColisionWithBuilding(nextPont);
                    this.collision.DetectColisionWithPlayer(nextPont);


                }
                if (e.KeyCode == Keys.Down)
                {
                    nextPont = new Point(this.player.Location.X, this.player.Location.Y + Config.GameConfig.TileSize);
                    if (this.CheckIsWalkable(nextPont))
                    {
                        this.player.Move(0, Config.GameConfig.TileSize);
                        Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][Game.Instance.Player.Location.X / Config.GameConfig.TileSize].PlayerId = Game.Instance.Player.Id;
                        Map.Instance.WorldMap[(Game.Instance.Player.Location.Y / Config.GameConfig.TileSize) - 1][(Game.Instance.Player.Location.X / Config.GameConfig.TileSize)].PlayerId = 0;
                    }
                    this.collision.DetectColisionWithBuilding(nextPont);
                    this.collision.DetectColisionWithPlayer(nextPont);
                }
            }
            //designer.DrawPlayer(this.player);
            Game.Instance.Designer.DrawMap(Map.Instance.CurrentMap(this.player));
            Game.Instance.Designer.DrawBots(this.player, Map.Instance.CurrentMap(this.player), Game.Instance.Bots);
            Game.Instance.Designer.DrawCars(this.player, Map.Instance.CurrentMap(this.player), Game.Instance.Cars);
            Game.Instance.Designer.DrawPlayer(this.player);

        }

        private bool CheckIsWalkable(Point check)
        {
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Walkable)
            {
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].PlayerId > 1)
                {
                    Game.Instance.Player.Health += 10;
                    Game.Instance.Player.InAction = true;
                    
                    return false;
                }
                
                return true;
            }
            return false;
        }
        //private bool DetectColisionWithBuilding(Point check)
        //{
        //    if(Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Walkable)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
