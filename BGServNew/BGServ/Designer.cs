using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using BGServ;
using BGServ.Humans;
using BulgarianReality.Humans;
using BulgarianReality.Transportation;

namespace BGServ
{
    public class Designer
    {
        private PictureBox designer;
        private Image img = new Bitmap(Config.GameConfig.WindowSizeX, Config.GameConfig.WindowSizeY);
        private Graphics device;

        private Human player = Game.Instance.Player;


        public Designer()
        {
            this.designer = new PictureBox();
            this.designer.Parent = Game.Instance.GameForm;
            this.device = Graphics.FromImage(this.img);
            designer.Width = Config.GameConfig.WindowSizeX;
            designer.Height = Config.GameConfig.WindowSizeY;
        }


        public void DrawPlayer()
        {
            this.designer.BackColor = Color.Transparent;
            this.device.DrawImage(this.player.Image, this.LocalCoordinates(this.player.Location));

            this.designer.Image = this.img;
        }

        public void DrawMap()
        {
            Tile[][] map = Map.Instance.CurrentMap(Game.Instance.Player);
            for (int y = 0; y < Config.GameConfig.GridY; y++)
            {
                for (int x = 0; x < Config.GameConfig.GridX; x++)
                {
                    device.DrawImage(map[y][x].Building.Image, x * 40, y * 40);
                }
            }
            this.designer.Image = this.img;
        }

        public void DrawBots(Human player, Tile[][] map, HashSet<Human> bots)
        {
            //List<Human> fiteredBots = new List<Human>();
            //HashSet<Human> bots = Game.Instance.Bots;
            //Map m = Map.Instance;
            //Tile[][] curMap = m.CurrentMap(Game.Instance.Player);
            //this.designer.BackColor = Color.Transparent;
            ////List<Human> fiteredBots = Game.Instance.Bots
            ////    .Where(i =>
            ////            i.Location.X > map[0][0].Location.X &&
            ////            i.Location.X < map[0][18].Location.X &&
            ////            i.Location.Y > map[0][0].Location.Y &&
            ////            i.Location.Y < map[15][0].Location.Y
            ////            ).ToList();
            ////foreach (var botinka in Game.Instance.Bots)
            ////{
            ////    this.device.DrawImage(botinka.Image, botinka.Location);
            ////}
            //for (int i = 0; i < 16; i++)
            //{
            //    for (int j = 0; j < 19; j++)
            //    {
            //        Human foundBot = bots.FirstOrDefault(id => id.Id == map[i][j].PlayerId);
            //        if (foundBot != null)
            //        {
            //            this.device.DrawImage(foundBot.Image, foundBot.Location);
            //        }
            //    }
            //}

            //if (Game.Instance.BotInAction != null)
            //{
            //    this.device.DrawImage(Game.Instance.BotInAction.Image, Game.Instance.BotInAction.Location);
            //}
            //this.designer.Image = this.img;

            this.designer.BackColor = Color.Transparent;
            Map visibleMap = Map.Instance;
            for (int y = 0; y < Config.GameConfig.GridY; y++)
            {
                for (int x = 0; x < Config.GameConfig.GridX; x++)
                {
                    Human foundBot = bots.FirstOrDefault(id => id.Id == map[y][x].PlayerId);
                    if (foundBot == null)
                    {
                        continue;
                    }
                    if (map[y][x].Location.X > visibleMap.CurrentMapStartGrid(player).X * Config.GameConfig.TileSize
                        &&
                        map[y][x].Location.X < (visibleMap.CurrentMapStartGrid(player).X * Config.GameConfig.TileSize +
                           Config.GameConfig.GridX * Config.GameConfig.TileSize)
                     &&
                         map[y][x].Location.Y > visibleMap.CurrentMapStartGrid(player).Y * Config.GameConfig.TileSize
                     &&
                        map[y][x].Location.Y < (visibleMap.CurrentMapStartGrid(player).Y * Config.GameConfig.TileSize +
                         Config.GameConfig.GridY * Config.GameConfig.TileSize))
                    {
                        this.device.DrawImage(foundBot.Image,foundBot.Location);
                    }
                }
            }


            //this.designer.Height = Config.GameConfig.TileSize;
            //this.designer.Width = Config.GameConfig.TileSize;
            this.designer.Image = this.img;
        }

        public void DrawCars(Tile[][] map)
        {
            this.designer.BackColor = Color.Transparent;
            List<Transport> fiteredCars = Game.Instance.Cars
                .Where(i =>
                        i.Location.X > map[0][0].Location.X &&
                        i.Location.X < map[0][18].Location.X &&
                        i.Location.Y > map[0][0].Location.Y &&
                        i.Location.Y < map[15][0].Location.Y
                        ).ToList();
            foreach (Transport car in fiteredCars)
            {
                this.device.DrawImage(car.Image, car.Location);

            }
            this.designer.Image = this.img;
        }

        private Point LocalCoordinates(Point location)
        {
            Point newLocation = new Point();
            newLocation.X = location.X % ((Config.GameConfig.GridX) * Config.GameConfig.TileSize);
            newLocation.Y = location.Y % ((Config.GameConfig.GridY) * Config.GameConfig.TileSize);
            return newLocation;
        }
    }
}
