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

        public Designer()
        {
            this.designer = new PictureBox();
            this.designer.Parent = Game.Instance.GameForm;
            this.device = Graphics.FromImage(this.img);
            designer.Width = Config.GameConfig.WindowSizeX;
            designer.Height = Config.GameConfig.WindowSizeY;
        }


        public void DrawPlayer(Human player)
        {

            //this.device.DrawImage(player.Image, player.Location);
            this.designer.BackColor = Color.Transparent;
            this.device.DrawImage(player.Image, this.LocalCoordinates(player.Location));

            //this.designer.Height = Config.GameConfig.TileSize;
            //this.designer.Width = Config.GameConfig.TileSize;
            this.designer.Image = this.img;

        }

        public void DrawMap(Tile[][] map)
        {
            Tile playTile = map[0][0];
            //designer.Width = Config.GameConfig.WindowSizeX;
            //designer.Height = Config.GameConfig.WindowSizeY;
            for (int y = 0; y < Config.GameConfig.GridY; y++)
            {

                for (int x = 0; x < Config.GameConfig.GridX; x++)
                {
                    device.DrawImage(map[y][x].Building.Image, x * 40, y * 40);
                }
            }

            this.designer.Image = this.img;
        }

        public void DrawBots(Human character, Tile[][] map, HashSet<Human> bot)
        {
            this.designer.BackColor = Color.Transparent;
            Map visibleMap = Map.Instance;
            for (int y = 0; y < Config.GameConfig.GridY; y++)
            {
                for (int x = 0; x < Config.GameConfig.GridX; x++)
                {
                    Human foundBot = bot.FirstOrDefault(i => i.Id == map[y][x].PlayerId);
                    if (map[y][x].PlayerId < 2 || foundBot == null)//|| bot.FirstOrDefault(i => i.Id == map[y][x].PlayerId).InAction)
                    {
                        continue;
                    }


                    if (foundBot.Location.X > visibleMap.CurrentMapStartGrid(Game.Instance.Player).X * Config.GameConfig.TileSize &&
                        foundBot.Location.X < (visibleMap.CurrentMapStartGrid(Game.Instance.Player).X * Config.GameConfig.TileSize +
                         Config.GameConfig.GridX * Config.GameConfig.TileSize))
                    {

                        this.device.DrawImage(foundBot.Image, x * 40, y * 40);
                    }
                    if (foundBot.Location.Y > visibleMap.CurrentMapStartGrid(Game.Instance.Player).Y * Config.GameConfig.TileSize &&
                        foundBot.Location.Y <
                        (visibleMap.CurrentMapStartGrid(Game.Instance.Player).Y * Config.GameConfig.TileSize +
                         Config.GameConfig.GridY * Config.GameConfig.TileSize))
                    {

                        this.device.DrawImage(foundBot.Image, x * 40, y * 40);
                    }
                }
            }
            if (Game.Instance.BotInAction != null)
            {
                this.device.DrawImage(Game.Instance.BotInAction.Image, Game.Instance.BotInAction.Location);
            }

            //this.designer.Height = Config.GameConfig.TileSize;
            //this.designer.Width = Config.GameConfig.TileSize;
            this.designer.Image = this.img;
        }

        private Point LocalCoordinates(Point location)
        {
            Point newLocation = new Point();
            newLocation.X = location.X % ((Config.GameConfig.GridX) * Config.GameConfig.TileSize);
            newLocation.Y = location.Y % ((Config.GameConfig.GridY) * Config.GameConfig.TileSize);
            return newLocation;
        }

        public void DrawCars(Human character, Tile[][] map, HashSet<Transport> car)
        {
            this.designer.BackColor = Color.Transparent;
            Map visibleMap = Map.Instance;
            for (int y = 0; y < Config.GameConfig.GridY; y++)
            {
                for (int x = 0; x < Config.GameConfig.GridX; x++)
                {
                    Transport foundBot = car.FirstOrDefault(i => i.Location == map[y][x].Location);
                    if (foundBot == null) //|| bot.FirstOrDefault(i => i.Id == map[y][x].PlayerId).InAction)
                    {
                        continue;
                    }


                    if (foundBot.Location.X >
                        visibleMap.CurrentMapStartGrid(Game.Instance.Player).X*Config.GameConfig.TileSize &&
                        foundBot.Location.X <
                        (visibleMap.CurrentMapStartGrid(Game.Instance.Player).X*Config.GameConfig.TileSize +
                         Config.GameConfig.GridX*Config.GameConfig.TileSize))
                    {

                        this.device.DrawImage(foundBot.Image, x*40, y*40);
                    }
                    if (foundBot.Location.Y >
                        visibleMap.CurrentMapStartGrid(Game.Instance.Player).Y*Config.GameConfig.TileSize &&
                        foundBot.Location.Y <
                        (visibleMap.CurrentMapStartGrid(Game.Instance.Player).Y*Config.GameConfig.TileSize +
                         Config.GameConfig.GridY*Config.GameConfig.TileSize))
                    {

                        this.device.DrawImage(foundBot.Image, x*40, y*40);
                    }
                }
            }

        }

    }
}
