
using System;
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

        private Game()
        {
            throw new NotImplementedException();
        }
        private Game(Form gameForm, Human player)
        {
            this.GameForm = gameForm;
            this.Player = player;
            //this.Run();
        }

        public void Run()
        {
            //this.BuildingSeed(map.WorldMap);
            //this.map = new Map(Game.player);
            this.map = new Map();
            Designer designer = new Designer();
            Seeder seeder = new Seeder(this.map);
            seeder.AddBiuldings();
            Tile[][] currentMap = this.map.CurrentMap(Game.player);

            designer.DrawMap(currentMap);
            designer.DrawPlayer(Game.Instance.Player);
        }

        private void BuildingSeed(Tile[][] map)
        {
            throw new NotImplementedException();
        }

        private void Draw()
        {

        }

        public Human Player {
            get { return Game.player; } 
            set { Game.player = value; } 
        }
        public Form GameForm { get; set; }

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
