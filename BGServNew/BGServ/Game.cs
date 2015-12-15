
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
        private Map map;
        private int id = 1;
        private HashSet<Human> bots;

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

            this.map = Map.Instance();
            Designer designer = new Designer();
            Seeder seeder = new Seeder(this.map);
            seeder.AddBiuldings();
            seeder.AddPeople();

            Tile[][] currentMap = this.map.CurrentMap(Game.player);

            designer.DrawMap(currentMap);
            designer.DrawBots(Game.player, currentMap, this.Bots);
            designer.DrawPlayer(Game.Instance.Player);
        }



        public int Id()
        {
            this.id++;
            return this.id;
        }

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
    }

}
