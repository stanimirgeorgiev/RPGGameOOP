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
                Game.Instance.Player.CollisionImage = @"images\unicredit.png";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Unicredit Bulbank";
                this.action = new Action("bank");
                Game.Instance.Player.MeetMsg = this.action.Msgs["bank"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Hospital)
            {
                Game.Instance.Player.CollisionImage = @"images\hospital.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Tokuda Hospital";
                this.action = new Action("hospital");
                Game.Instance.Player.MeetMsg = this.action.Msgs["hospital"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Office)
            {
                Game.Instance.Player.CollisionImage = @"images\office.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Softuni office";
                this.action = new Action("office");
                Game.Instance.Player.MeetMsg = this.action.Msgs["office"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Supermarket)
            {
                Game.Instance.Player.CollisionImage = @"images\metrocash.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Metro cash n carry";
                this.action = new Action("supermarket");
                Game.Instance.Player.MeetMsg = this.action.Msgs["supermarket"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Coffee)
            {
                Game.Instance.Player.CollisionImage = @"images\starbucks.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Starbucks";
                this.action = new Action("coffee");
                Game.Instance.Player.MeetMsg = this.action.Msgs["coffee"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Restaurant)
            {
                Game.Instance.Player.CollisionImage = @"images\happy.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Happy SHUSHI";
                this.action = new Action("restaurant");
                Game.Instance.Player.MeetMsg = this.action.Msgs["restaurant"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is PoliceStation)
            {
                Game.Instance.Player.CollisionImage = @"images\police.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Sofia police station";
                this.action = new Action("police");
                Game.Instance.Player.MeetMsg = this.action.Msgs["policastation"];
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
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("MassMurderer");
                    bot.MeetMsg = this.action.Msgs["massmurderer"];
                }
                if (bot is Thief)
                {
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("Thief");
                    bot.MeetMsg = this.action.Msgs["thief"];
                }
                if (bot is Rapist)
                {
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("Rapist");
                    bot.MeetMsg = this.action.Msgs["rapist"];
                }
                if (bot is Developer)
                {
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("Developer");
                    bot.MeetMsg = this.action.Msgs["developer"];

                }
                if (bot is Doctor)
                {
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("Doctor");
                    bot.MeetMsg = this.action.Msgs["doctor"];
                    
                }
                if (bot is Mayor)
                {
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("Mayor");
                    bot.MeetMsg = this.action.Msgs["mayor"];
                }
                if (bot is Policeman)
                {
                    Game.Instance.Player.CollisionImage = @"images\Avatar1.jpg";
                    Game.Instance.Player.InAction = true;
                    Game.Instance.Player.Oponent = bot;
                    this.action = new Action("Policeman");
                    bot.MeetMsg = this.action.Msgs["policeman"];
                }
                
            }
        }
    }
}
