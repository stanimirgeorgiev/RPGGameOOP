﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WindowsFormsApplication1;
using BGServ;
using BulgarianReality.Humans;

namespace BGServ
{
    class Game
    {
        private static Game instance;
        private static Form gameForm;
        private static Human player;
        private int id = 1;
        private HashSet<Human> bots;
        private Designer designer;
        private int thirdTicker = 0;

        private Game()
        {
            throw new NotImplementedException();
        }
        private Game(Form gameForm, Human player)
        {
            this.GameForm = gameForm;
            this.Player = player;
        }

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
            int[] directionEast = {0, 2, 3};
            int[] directionSouth = {0, 1, 3};
            


            foreach (var bot in this.Bots)
            {
                thirdTicker++;
                if (thirdTicker == 500)
                {
                    foreach (var bots in Game.Instance.Bots)
                    {
                        bots.Direction = rand.Next(4);
                        thirdTicker = 0;
                    }
                }
                switch (bot.Direction)
                {
                    case 0:
                        if (Map.Instance.WorldMap[bot.Location.Y / 40 - 1][bot.Location.X / 40].Walkable)
                        {
                            Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40].PlayerId = 0;
                            Map.Instance.WorldMap[bot.Location.Y / 40 - 1][bot.Location.X / 40].PlayerId = bot.Id;
                            bot.Move(0, -40);
                        }
                        else
                        {
                            bot.Direction = rand.Next(1, 4);
                        }
                        break;
                    case 1:
                        if (Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40 + 1].Walkable)
                        {
                            Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40].PlayerId = 0;
                            Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40 + 1].PlayerId = bot.Id;
                            bot.Move(40, 0);
                        }
                        else
                        {
                            bot.Direction = directionEast[rand.Next(0, 3)];
                        }
                        break;
                    case 2:
                        if (Map.Instance.WorldMap[bot.Location.Y / 40 + 1][bot.Location.X / 40].Walkable)
                        {
                            Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40].PlayerId = 0;
                            Map.Instance.WorldMap[bot.Location.Y / 40 + 1][bot.Location.X / 40].PlayerId = bot.Id;
                            bot.Move(0, 40);
                        }
                        else
                        {
                            bot.Direction = directionSouth[rand.Next(0, 3)];

                        }
                        break;
                    case 3:
                        if (Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40 - 1].Walkable)
                        {
                            Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40].PlayerId = 0;
                            Map.Instance.WorldMap[bot.Location.Y / 40][bot.Location.X / 40 - 1].PlayerId = bot.Id;
                            bot.Move(-40, 0);
                        }
                        else
                        {
                            bot.Direction = rand.Next(0, 3);
                        }
                        break;

                }
            }

            this.designer.DrawMap(Map.Instance.CurrentMap(Game.Instance.Player));
            this.designer.DrawBots(Game.player, Map.Instance.CurrentMap(Game.Instance.Player), this.Bots);
            this.designer.DrawPlayer(Game.Instance.Player);

        }
    }

}
