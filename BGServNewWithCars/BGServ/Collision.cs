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
                Game.Instance.Player.CollisionImage = @"images\credit.png";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Credit Bank";
                this.action = new Action("bank");
                Game.Instance.Player.MeetMsg = this.action.Msgs["bank"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Hospital)
            {
                Game.Instance.Player.CollisionImage = @"images\HospitalAvatar.png";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Uni Hospital";
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
                Game.Instance.Player.BuilDingName = "Metro cash & carry";
                this.action = new Action("supermarket");
                Game.Instance.Player.MeetMsg = this.action.Msgs["supermarket"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Coffee)
            {
                Game.Instance.Player.CollisionImage = @"images\Coffee.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Coffee";
                this.action = new Action("coffee");
                Game.Instance.Player.MeetMsg = this.action.Msgs["coffee"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Restaurant)
            {
                Game.Instance.Player.CollisionImage = @"images\Restaurant.jpg";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Bar & Grill";
                this.action = new Action("restaurant");
                Game.Instance.Player.MeetMsg = this.action.Msgs["restaurant"];
            }
            if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is PoliceStation)
            {
                Game.Instance.Player.CollisionImage = @"images\PoliceAvatar.png";
                Game.Instance.Player.InAction = true;
                Game.Instance.Player.BuilDingName = "Sofia Police Station";
                this.action = new Action("police");
                Game.Instance.Player.MeetMsg = this.action.Msgs["policestation"];
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
                    if (Game.Instance.Player.Gender == BulgarianReality.Enums.Gender.Male)
                    {

                        Game.Instance.Player.CollisionImage = @"images\MassMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("MassMurderer");
                        bot.MeetMsg = this.action.Msgs["massmurderer"];
                    }
                    else
                    {

                        Game.Instance.Player.CollisionImage = @"images\MassFemale.png";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("MassMurderer");
                        bot.MeetMsg = this.action.Msgs["massmurderer"];
                    }
                }
                if (bot is Thief)
                {
                    if (Game.Instance.Player.Gender == BulgarianReality.Enums.Gender.Male)
                    {
                        Game.Instance.Player.CollisionImage = @"images\ThiefMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Thief");
                        bot.MeetMsg = this.action.Msgs["thief"];
                    }
                    else
                    {
                        Game.Instance.Player.CollisionImage = @"images\ThiefFemale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Thief");
                        bot.MeetMsg = this.action.Msgs["thief"];
                    }

                }
                if (bot is Rapist)
                {
                    if (bot.Gender == BulgarianReality.Enums.Gender.Male)
                    {
                        Game.Instance.Player.CollisionImage = @"images\RapistMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Rapist");
                        bot.MeetMsg = this.action.Msgs["rapist"];
                    }
                    else
                    {
                        Game.Instance.Player.CollisionImage = @"images\RapistFemale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Rapist");
                        bot.MeetMsg = this.action.Msgs["rapist"];
                    }
                }
                if (bot is Developer)
                {
                    if (bot.Gender == BulgarianReality.Enums.Gender.Male)
                    {
                        Game.Instance.Player.CollisionImage = @"images\DeveloperMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Developer");
                        bot.MeetMsg = this.action.Msgs["developer"];
                    }
                    else
                    {
                        Game.Instance.Player.CollisionImage = @"images\DeveloperFemale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Developer");
                        bot.MeetMsg = this.action.Msgs["developer"];

                    }

                }
                if (bot is Doctor)
                {
                    if (bot.Gender == BulgarianReality.Enums.Gender.Male)
                    {
                        Game.Instance.Player.CollisionImage = @"images\DoctorMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Doctor");
                        bot.MeetMsg = this.action.Msgs["doctor"];
                    }
                    else
                    {
                        Game.Instance.Player.CollisionImage = @"images\DoctorFemale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Doctor");
                        bot.MeetMsg = this.action.Msgs["doctor"];
                    }

                }
                if (bot is Mayor)
                {
                    if (bot.Gender == BulgarianReality.Enums.Gender.Male)
                    {
                        Game.Instance.Player.CollisionImage = @"images\MayorMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Mayor");
                        bot.MeetMsg = this.action.Msgs["mayor"];
                    }
                    else
                    {
                        Game.Instance.Player.CollisionImage = @"images\MayorFemale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Mayor");
                        bot.MeetMsg = this.action.Msgs["mayor"];
                    }
                }
                if (bot is Policeman)
                {
                    if (bot.Gender == BulgarianReality.Enums.Gender.Male)
                    {
                        Game.Instance.Player.CollisionImage = @"images\PoliceMale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Policeman");
                        bot.MeetMsg = this.action.Msgs["policeman"];
                    }
                    else
                    {
                        Game.Instance.Player.CollisionImage = @"images\PoliceFemale.jpg";
                        Game.Instance.Player.InAction = true;
                        Game.Instance.Player.Oponent = bot;
                        this.action = new Action("Policeman");
                        bot.MeetMsg = this.action.Msgs["policeman"];
                    }
                }

            }
        }
    }
}
