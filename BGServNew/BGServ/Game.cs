
using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using BulgarianReality.Humans;

namespace WindowsFormsApplication1
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
            Map map = new Map();
            this.map = map;
            this.map.LoadMap();
            //this.Draw();
        }

        private void Draw()
        {
            
        }

        public Human Player { get; set; }
        public Form GameForm { get; set; }

        public static Game Instance
        {
            get
            {
            if (Game.instance == null)
            {
                Game.instance = new Game(Game.gameForm,Game.player );
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
