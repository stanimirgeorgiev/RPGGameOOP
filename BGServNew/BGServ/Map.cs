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
        private Tile[][] worldMap ;
        private Tile[][] currentMap;

        public Map()
        {
            this.LoadMap();
            //this.CurrentMap();
        }

        public Tile[][] CurrMap
        {
            get { return this.currentMap; }
            private set { this.currentMap = value; }
        }

        public Tile[][] CurrentMap(Human player)
        {
            int startX = ((player.Location.X / Config.GameConfig.TileSize) / Config.GameConfig.GridX) * Config.GameConfig.GridX;
            int startY = ((player.Location.Y / Config.GameConfig.TileSize) / Config.GameConfig.GridY) * Config.GameConfig.GridY;

            Tile[][] currentMap = new Tile[Config.GameConfig.GridY][];

            for (int y = 0; y < Config.GameConfig.GridY; y++)
            {
                currentMap[y] = new Tile[Config.GameConfig.GridX];
                for (int x = 0; x < Config.GameConfig.GridX; x++)
                {
                    currentMap[y][x] = this.worldMap[y + startY][x + startX];
                }
            }
            return currentMap;
        }

        public Tile[][] WorldMap
        {
            get { return this.worldMap; }
            private set { this.currentMap = value; }
        }

        //private Tile this[int y, int x]
        //{
        //    get { return this.worldMap[y][x]; }
        //    set { this.worldMap[y][x] = value; }
        //}

        public void LoadMap()
        {
            Human dummyHumman = new DummyHuman();
            Building dummyBuilding = new DummyBuilding();
            AlleyTile alleyTile = new AlleyTile();
            ParkTile parkTile = new ParkTile();
            WaterTile waterTile = new WaterTile();
            this.worldMap = new Tile[Config.GameConfig.GridMapY][];
            for (int raw = 0; raw < Config.GameConfig.GridMapY; raw++)
            {
                this.worldMap[raw] = new Tile[Config.GameConfig.GridMapX];
                for (int column = 0; column < Config.GameConfig.GridMapX; column++)
                {
                    this.worldMap[raw][column] = new Tile(new Point(raw * 40, column * 40), dummyHumman, dummyBuilding, false);
                }
            }

            using (StreamReader reader = new StreamReader(@"MapTileData\map.txt"))
            {
                for (int y = 0; y < Config.GameConfig.GridMapY; y++)
                {
                    string line = reader.ReadLine();

                    for (int x = 0; x < Config.GameConfig.GridMapX; x++)
                    {
                        switch (line[x].ToString())
                        {
                            case "0":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, new StreetTile(false), false);
                                break;
                            case "1":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, dummyBuilding, dummyBuilding.Walkable);
                                break;
                            case "2":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, parkTile, parkTile.Walkable);
                                break;
                            case "3":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, alleyTile, alleyTile.Walkable);
                                break;
                            case "4":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, new StreetTile(true), true);
                                break;
                            case "5":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, new StreetTile(true), true);
                                break;
                            case "9":
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, waterTile, waterTile.Walkable);
                                break;
                            default:
                                this.worldMap[y][x] = new Tile(new Point(y * 40, x * 40), dummyHumman, waterTile, waterTile.Walkable);
                                break;
                        }
                    }
                }
            }
        }
    }
}

