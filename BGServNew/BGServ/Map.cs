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
using WindowsFormsApplication1;
using BGServ.Humans;
using BulgarianReality.Buildings;
using BulgarianReality.Humans;

namespace BGServ
{
    class Map
    {
        private Tile[][] worldMap = new Tile[Config.GameConfig.MapY][];
        private Human player;
        private Tile[][] currentMap;

        public Map(Human player)
        {
            this.LoadMap();
            this.player = player;
        }

        public Tile[][] CurrMap
        {
            get { return this.currentMap; }
            private set { this.currentMap = value; }
        }

        public void CurrentMap()
        {
            int startX = ((this.player.Location.X/Config.GameConfig.TileSize) % Config.GameConfig.GridX)*Config.GameConfig.GridX;
            int startY = ((this.player.Location.Y/Config.GameConfig.TileSize) % Config.GameConfig.GridY)*Config.GameConfig.GridY;
            int endX = startX + Config.GameConfig.GridX;
            int endY = startY + Config.GameConfig.GridY;
            Tile[][] currentMap = new Tile[Config.GameConfig.GridY][];

            for (int y = startY; y < endY; y++)
            {
                currentMap[y] = new Tile[Config.GameConfig.GridX];
                for (int x = startX; x < endX; x++)
                {
                    currentMap[y][x] = this.worldMap[y][x];
                }
            }
            this.currentMap = currentMap;
        }

        public Tile[][] WorldMap
        {
            get { return this.worldMap; }
            private set { this.currentMap = value; }
        }

        private Tile this[int y, int x]
        {
            get { return this.worldMap[y][x]; }
            set { this.worldMap[y][x] = value; }
        }

        public void LoadMap()
        {
            Human dummyHumman = new DummyHuman();
            Building dummyBuilding = new DummyBuilding();
            AlleyTile alleyTile = new AlleyTile();
            ParkTile parkTile = new ParkTile();
            WaterTile waterTile = new WaterTile();
            for (int raw = 0; raw < Config.GameConfig.MapY; raw++)
            {
                this.worldMap[raw] = new Tile[Config.GameConfig.MapX];
                for (int column = 0; column < Config.GameConfig.MapX; column++)
                {
                    this.worldMap[raw][column] = new Tile(new Point(raw * 40, column * 40), dummyHumman, dummyBuilding, false);
                }
            }

            using (StreamReader reader = new StreamReader(@"MapTileData\map.txt"))
            {
                for (int y = 0; y < 64; y++)
                {
                    string line = reader.ReadLine();

                    int lineLength = line.Length;
                    for (int x = 0; x < 95; x++)
                    {
                        Tile currentTile;
                        switch (line[x].ToString())
                        {

                            case "0":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, new StreetTile(false), false);
                                break;
                            case "1":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, dummyBuilding, dummyBuilding.Walkable);
                                break;
                            case "2":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, parkTile, parkTile.Walkable);
                                break;
                            case "3":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, alleyTile, alleyTile.Walkable);
                                break;
                            case "4":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, new StreetTile(true), true);
                                break;
                            case "5":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, new StreetTile(true), true);
                                break;
                            case "9":
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, waterTile, waterTile.Walkable);
                                break;
                            default:
                                this[y, x] = new Tile(new Point(y * 40, x * 40), dummyHumman, waterTile, waterTile.Walkable);
                                break;
                        }
                    }
                }
            }
        }
    }
}

