
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WindowsFormsApplication1;
using BGServ;
using BulgarianReality.Humans;
using BulgarianReality.Buildings;
using System.Linq;
using BGServ.Humans;
using BulgarianReality.Transportation;

namespace BGServ
{
    class Game
    {
        private static Game instance;
        private static Form gameForm;
        private static Human player;
        private int id = 2;
        private HashSet<Human> bots;
        private Designer designer;
        private int thirdTicker = 0;
        private Human botInAction;
        private Action action;

        private Game()
        {
            throw new NotImplementedException();
        }
        private Game(Form gameForm, Human player)
        {
            this.GameForm = gameForm;
            this.Player = player;
        }

        public Human BotInAction { get { return this.botInAction; } }

        public HashSet<Transport> Cars { get; set; }
        public HashSet<Human> Bots { get { return this.bots; } set { this.bots = value; } }
        public Human Player { get { return Game.player; } set { Game.player = value; } }
        public Form GameForm { get; set; }
        public void Run()
        {

            Designer designer = new Designer();
            Seeder seeder = new Seeder();

            this.designer = designer;
            seeder.AddBiuldings();
            seeder.AddPeople();
            seeder.AddCars();
            Map.Instance.WorldMap[Game.Instance.Player.Location.Y / Config.GameConfig.TileSize][Game.Instance.Player.Location.X / Config.GameConfig.TileSize].PlayerId = Game.Instance.Player.Id;

            Tile[][] currentMap = Map.Instance.CurrentMap(Game.player);

            designer.DrawMap(currentMap);
            designer.DrawBots(Game.player, currentMap, this.Bots);
            designer.DrawPlayer(Game.Instance.Player);
        }


        public int Id()
        {
            this.id++;
            return this.id;
        }
        public Designer Designer { get { return this.designer; } set { this.designer = value; } }

        public static Game Instance
        {
            get
            {
                if (Game.instance == null)
                {
                    Game.instance = new Game(Game.gameForm, Game.player);
                }
                return Game.instance;
            }
        }

        public static void SetForm(Form gameForm, Human player)
        {
            Game.gameForm = gameForm;
            Game.player = player;
        }


        public void MoveBots()
        {
            Random rand = new Random();
            int[] directionEast = { 0, 2, 3 };
            int[] directionSouth = { 0, 1, 3 };
            bool botInActionFound = false;
            Human botToRemove = new DummyHuman();




            foreach (var bot in this.Bots)
            {
                thirdTicker++;
                if (thirdTicker == 1000)
                {
                    Player.Health -= 10;
                    Player.InAction = false;
                    foreach (var bots in Game.Instance.Bots)
                    {
                        bots.Direction = rand.Next(4);
                        thirdTicker = 0;
                    }
                }

                switch (bot.Direction)
                {

                    case 0:
                        Game.player.Image = Game.player.ImageDirection[0];
                        if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].Walkable)
                        {
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId == Game.Instance.Player.Id)
                            {

                                //Game.Instance.Player.Health+=100;
                                botToRemove = Game.Instance.Bots.FirstOrDefault(i => i.Id == Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId);
                                botInActionFound = true;
                                this.botInAction = botToRemove;
                                Game.player.InAction = true;
                                //this.action = new Action("joy");
                                break;
                            }
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId == 0
                                )//&& !(Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].Building is Building))
                            {


                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId = 0;
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId = bot.Id;
                                bot.Move(0, -Config.GameConfig.TileSize);
                            }
                        }
                        else
                        {
                            bot.Direction = rand.Next(1, 4);
                        }
                        break;
                    case 1:
                        Game.player.Image = Game.player.ImageDirection[1];
                        if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize + 1].Walkable)
                        {

                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId == Game.Instance.Player.Id)//&& !botToRemove.InAction )
                            {
                                //Collision detection;
                                botToRemove = Game.Instance.Bots.FirstOrDefault(i => i.Id == Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId);
                                //Game.Instance.Player.Health += 100;
                                botInActionFound = true;
                                botToRemove.InAction = true;
                                this.botInAction = botToRemove;
                                this.action = new Action("joy");
                                break;

                                // break;
                            }
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize + 1].PlayerId == 0
                                )//&& !(Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].Building is Building))
                            {
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId = 0;
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize + 1].PlayerId = bot.Id;
                                bot.Move(Config.GameConfig.TileSize, 0);
                            }
                        }
                        else
                        {
                            bot.Direction = directionEast[rand.Next(0, 3)];
                        }
                        break;
                    case 2:
                        Game.player.Image = Game.player.ImageDirection[2];
                        if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize + 1][bot.Location.X / Config.GameConfig.TileSize].Walkable)
                        {
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId == Game.Instance.Player.Id)
                            {
                                //Collision detection;
                                //Game.Instance.Player.Health += 100;
                                botToRemove = Game.Instance.Bots.FirstOrDefault(i => i.Id == Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId);
                                botInActionFound = true;
                                this.botInAction = botToRemove;
                                Game.player.InAction = true;
                                //this.action = new Action("joy");
                                break;
                                // break;
                            }
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize + 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId == 0)
                            //  && !(Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].Building is Building))
                            {
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId = 0;
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize + 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId = bot.Id;
                                bot.Move(0, Config.GameConfig.TileSize);
                            }
                        }
                        else
                        {
                            bot.Direction = directionSouth[rand.Next(0, 3)];

                        }
                        break;
                    case 3:
                        Game.player.Image = Game.player.ImageDirection[3];
                        if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize - 1].Walkable)
                        {
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].PlayerId == Game.Instance.Player.Id)
                            {
                                //Collision detection;
                                //Game.Instance.Player.Health += 100;
                                botToRemove = Game.Instance.Bots.FirstOrDefault(i => i.Id == Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId);
                                botInActionFound = true;
                                this.botInAction = botToRemove;
                                Game.player.InAction = true;
                                // this.action = new Action("joy");
                                break;
                                //break;
                            }
                            if (Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize - 1].PlayerId == 0)
                            //&& !(Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize - 1][bot.Location.X / Config.GameConfig.TileSize].Building is Building))
                            {
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize].PlayerId = 0;
                                Map.Instance.WorldMap[bot.Location.Y / Config.GameConfig.TileSize][bot.Location.X / Config.GameConfig.TileSize - 1].PlayerId = bot.Id;
                                bot.Move(-Config.GameConfig.TileSize, 0);
                            }
                        }
                        else
                        {
                            bot.Direction = rand.Next(0, 3);
                        }
                        break;

                }
            }
            if (botInActionFound)
            {
                Game.Instance.Bots.Remove(botToRemove);
                botInActionFound = false;

            }

            this.designer.DrawMap(Map.Instance.CurrentMap(Game.Instance.Player));
            this.designer.DrawBots(Game.player, Map.Instance.CurrentMap(Game.Instance.Player), this.Bots);
            //this.designer.DrawCars(Game.player, Map.Instance.CurrentMap(Game.Instance.Player), this.Cars);
            this.MoveCars();
            this.designer.DrawPlayer(Game.Instance.Player);

        }

        public void MoveCars()
        {
            Random rand = new Random();
            int index;

            foreach (var car in this.Cars)
            {
                List<int> direct = new List<int>();
                switch (car.Direction)
                {
                    case 0:
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize - 1][car.Location.X / Config.GameConfig.TileSize].IsStreet)
                        {
                            direct.Add(0);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize][car.Location.X / Config.GameConfig.TileSize + 1].IsStreet)
                        {
                            direct.Add(1);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize][car.Location.X / Config.GameConfig.TileSize - 1].IsStreet)
                        {
                            direct.Add(3);
                        }
                        if (direct.Count == 0)
                        {
                            break;
                        }
                        index = rand.Next(0, direct.Count());
                        switch (direct[index])
                        {
                            case 0:
                                car.Direction = 0;
                                car.Move(0, -Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 1:
                                car.Direction = 1;
                                car.Move(Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 2:
                                car.Direction = 2;
                                car.Move(0, Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 3:
                                car.Direction = 3;
                                car.Move(-Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                        }

                        break;
                    case 1:

                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize][car.Location.X / Config.GameConfig.TileSize + 1].IsStreet)
                        {
                            direct.Add(1);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize - 1][car.Location.X / Config.GameConfig.TileSize].IsStreet)
                        {
                            direct.Add(0);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize + 1][car.Location.X / Config.GameConfig.TileSize].IsStreet)
                        {
                            direct.Add(2);
                        }
                        if (direct.Count == 0)
                        {
                            break;
                        }
                        index = rand.Next(0, direct.Count());
                        switch (direct[index])
                        {
                            case 0:
                                car.Direction = 0;
                                car.Move(0, -Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 1:
                                car.Direction = 1;
                                car.Move(Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 2:
                                car.Direction = 2;
                                car.Move(0, Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 3:
                                car.Direction = 3;
                                car.Move(-Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                        }

                        break;
                    case 2:

                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize + 1][car.Location.X / Config.GameConfig.TileSize].IsStreet)
                        {
                            direct.Add(2);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize][car.Location.X / Config.GameConfig.TileSize + 1].IsStreet)
                        {
                            direct.Add(1);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize][car.Location.X / Config.GameConfig.TileSize - 1].IsStreet)
                        {
                            direct.Add(3);
                        }
                        if (direct.Count == 0)
                        {
                            break;
                        }
                        index = rand.Next(0, direct.Count());
                        switch (direct[index])
                        {
                            case 0:
                                car.Direction = 0;
                                car.Move(0, -Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 1:
                                car.Direction = 1;
                                car.Move(Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 2:
                                car.Direction = 2;
                                car.Move(0, Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 3:
                                car.Direction = 3;
                                car.Move(-Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                        }

                        break;
                    case 3:

                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize][car.Location.X / Config.GameConfig.TileSize - 1].IsStreet)
                        {
                            direct.Add(3);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize + 1][car.Location.X / Config.GameConfig.TileSize].IsStreet)
                        {
                            direct.Add(2);
                        }
                        if (Map.Instance.WorldMap[car.Location.Y / Config.GameConfig.TileSize - 1][car.Location.X / Config.GameConfig.TileSize].IsStreet)
                        {
                            direct.Add(0);
                        }
                        if (direct.Count == 0)
                        {
                            break;
                        }
                        index = rand.Next(0, direct.Count());
                        switch (direct[index])
                        {
                            case 0:
                                car.Direction = 0;
                                car.Move(0, -Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 1:
                                car.Direction = 1;
                                car.Move(Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 2:
                                car.Direction = 2;
                                car.Move(0, Config.GameConfig.TileSize);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                            case 3:
                                car.Direction = 3;
                                car.Move(-Config.GameConfig.TileSize, 0);
                                car.Image = car.DirectionImage[car.Direction];
                                break;
                        }
                        //else
                        //{
                        //    car.Direction = 1;
                        //    car.Move(Config.GameConfig.TileSize, 0);
                        //    car.Image = car.DirectionImage[car.Direction];
                        //    break;
                        //}
                        break;
                }
            }
            this.designer.DrawCars(Game.player, Map.Instance.CurrentMap(Game.Instance.Player), this.Cars);
        }
        public void DetectColision()
        {
            foreach (var bot in this.Bots)
            {
                if (this.Player.Location.X == bot.Location.X && this.Player.Location.Y == bot.Location.Y)
                {
                    MessageBox.Show("COLLISTION");
                }
            }

        }


    }

}
