using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulgarianReality.Buildings;
using BulgarianReality.Humans;

namespace WindowsFormsApplication1
{
    class Map
    {
        private Tile[][] worldMap = new Tile[Config.GameConfig.MapY][];
        public Map()
        {
            this.LoadMap();
            this.DrawPlayers();
            this.CreateMap();
        }

        private void DrawPlayers()
        {
            
            PictureBox canvas = new PictureBox();
            canvas.Height = 40;
            canvas.Width = 40;
            canvas.Parent = Game.Instance.GameForm;
            canvas.Image = new Bitmap(@"images\PlayerPartySprite.png");
        }

        public Tile this[int x, int y]
        {
            get { return this.worldMap[y][x]; }
            set { this.worldMap[y][x] = value; }
        }

        private void CreateMap()
        {
            //PictureBox proba = new PictureBox();
            //proba.Width = Game.Instance.GameForm.Width;
            //proba.Height = Game.Instance.GameForm.Height;
            //proba.BackColor = Color.Transparent;
            //proba.Parent = Game.Instance.GameForm;

            Graphics device;
            //device = Game.Instance.GameForm.CreateGraphics();
            Image img = new Bitmap(Game.Instance.GameForm.Width, Game.Instance.GameForm.Height);
            device = Graphics.FromImage(img);
            for (int i = 0; i < 95; i++)
            {
                for (int j = 0; j < 64; j++)
                {
                    device.DrawImage(this[i,j].Image, this[i,j].Location);
                }
            }
            
            PictureBox canvas = new PictureBox();
            canvas.Height = 1000;
            canvas.Width = 1000;
            canvas.Parent = Game.Instance.GameForm;
            canvas.Image = img;
        }

        public void LoadMap()
        {
            for (int raw = 0; raw < Config.GameConfig.MapY; raw++)
            {
                this.worldMap[raw] = new Tile[Config.GameConfig.MapX];
                for (int column = 0; column < Config.GameConfig.MapX; column++)
                {
                    this.worldMap[raw][column] = new Tile(new Point(raw * 40, column * 40), new Bitmap(@"images\WaterTile.png"), new Human(), new Building(), true);
                }
            }

            StreamReader reader = new StreamReader(@"MapTileData\map.txt");

            for (int y = 0; y < 64; y++)
            {
                string line = reader.ReadLine();
                Human dummyHumman = new Human();
                Building dummyBuilding = new Building();

                int lineLength = line.Length;
                for (int x = 0; x < 64; x++)
                {
                    Tile currentTile;
                    switch (line[x].ToString())
                    {

                        case "0":
                            this[y,x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\StreetTile.png"), new Human(), new Building(), true);
                            //this.PlayMap[y][x] = new Tile();

                            break;
                        case "1":
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\BuildingTile.png"), new Human(), new Building(), true);
                            //this.PlayMap[y][x] = new Tile();

                            break;
                        case "2":
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\GrassTile.png"), new Human(), new Building(), true);
                            //this.PlayMap[y][x] = new Tile();

                            break;
                        case "3":
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\AlleyTile.png"), new Human(), new Building(), true);
                            //this.PlayMap[y][x] = new Tile();

                            break;
                        case "4":
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\ZebraVTile.png"), new Human(), new Building(), true);
                            //this.PlayMap[y][x] = new Tile();

                            break;
                        case "5":
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\ZebraHTile.png"), new Human(), new Building(), true);
                            //this.PlayMap[y][x] = new Tile();

                            break;
                        case "9":
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\WaterTile.png"), new Human(), new Building(), true);
                            //Image img = new Bitmap(@"images\WaterTile.png");
                            //Human play = new Human();
                            //Building build = new Building();
                            //this.PlayMap[y][x] = new Tile(new Point(y * 40, x * 40), img, play, build, true);
                            //Tile tile = new Tile();
                            ////this.PlayMap[y][x] = tile;
                            //this.PlayMap[y][x].Location = new Point(y * 40, x * 40);
                            //this.PlayMap[y][x].Image = img;
                            //this.PlayMap[y][x].Building = build;
                            //this.PlayMap[y][x].Player = play;
                            //this.PlayMap[y][x].Walkable = true;


                            break;
                        default:
                            //this.PlayMap[y][x] = new Tile(new Point(y * 40, x * 40), new Bitmap("WaterTile.png"), new Human(), new Building(), true);
                            this[y, x] = new Tile(new Point(y * 40, x * 40), new Bitmap(@"images\WaterTile.png"), new Human(), new Building(), true);

                            break;
                    }
                }
            }
            reader.Close();
        }
    }
}

