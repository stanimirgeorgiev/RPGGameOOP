using BulgarianReality.Buildings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulgarianReality.Humans;
using BulgarianReality.Humans.Criminals;
using BulgarianReality.Humans.Workers;

namespace BGServ
{
    public class Collision
    {
        private Action action;

        public Collision()
        {

        }
        public void DetectColisionWithBuilding(Point check)
        {
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Bank)
            {
                Game.Instance.Player.OponentImage = @"images\bank.png";
                Game.Instance.Player.InAction = true;
                this.action = new Action("bank");
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Hospital)
            {
                Game.Instance.Player.OponentImage = @"images\hospital.png";
                Game.Instance.Player.InAction = true;
                this.action = new Action("hospital");
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Office)
            {
                Game.Instance.Player.OponentImage = @"images\office.png";
                Game.Instance.Player.InAction = true;
                this.action = new Action("office");
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Supermarket)
            {
                this.action = new Action("supermarket");
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Coffee)
            {
                this.action = new Action("coffee");
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Restaurant)
            {
                this.action = new Action("restaurant");
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Restaurant)
            {
                this.action = new Action("police");
            }
        }
        public void DetectColisionWithPlayer(Point check)
        {
            int botID = Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].PlayerId;
            if (botID > 2)
            {
                Human bot = Game.Instance.Bots.FirstOrDefault(id => id.Id == botID);

                if (bot is MassMurderer)
                {
                    this.action = new Action("MassMurderer");
                }
                if (bot is Thief)
                {
                    this.action = new Action("Thief");
                }
                if (bot is Rapist)
                {
                    this.action = new Action("Rapist");
                }
                if (bot is Developer)
                {
                    Game.Instance.Player.OponentImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.OponentId = bot;
                    this.action = new Action("Developer");
                }
                if (bot is Doctor)
                {
                    this.action = new Action("Doctor");
                }
                if (bot is Mayor)
                {
                    this.action = new Action("Mayor");
                }
                if (bot is Policeman)
                {
                    this.action = new Action("Policeman");
                }
            }
        }
    }
}
