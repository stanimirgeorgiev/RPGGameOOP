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
    public class Map
    {
        private Tile[][] worldMap ;
        private Tile[][] currentMap;
        private List<Tile> dummyBuildings;
        private List<Tile> walkableTiles;
        private List<Tile> nonWalkableTiles;
        private static Map instance = null;

        private Map()
        {
            this.LoadMap();
            //this.CurrentMap();
        }

        public Tile[][] CurrMap
        {
            get { return this.currentMap; }
            private set { this.currentMap = value; }
        }



        public Tile[][] WorldMap
        {
            get { return this.worldMap; }
            private set { this.currentMap = value; }
        }

        public List<Tile> DummyBuildings { get { return this.dummyBuildings; } set { this.dummyBuildings = value; } }
        public List<Tile> WalkableTiles { get { return this.walkableTiles; } set { this.walkableTiles = value; } }
        public List<Tile> NonWalkableTiles { get { return this.nonWalkableTiles; } set { this.nonWalkableTiles = value; } }
        public Tile[][] CurrentMap(Human player)
        {
            int startX = CurrentMapStartGrid(player).X;
            int startY = CurrentMapStartGrid(player).Y;
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

        public Point CurrentMapStartGrid(Human player)
        {
            int startX = ((player.Location.X / Config.GameConfig.TileSize) / Config.GameConfig.GridX) * Config.GameConfig.GridX;
            int startY = ((player.Location.Y / Config.GameConfig.TileSize ) / Config.GameConfig.GridY) * Config.GameConfig.GridY;
            Point startCoordinates = new Point(startX, startY);
            return startCoordinates;
        }
        public void LoadMap()
        {
            MapTile dummyMapTile = new DummyMapTile();
            AlleyTile alleyTile = new AlleyTile();
            ParkTile parkTile = new ParkTile();
            WaterTile waterTile = new WaterTile();
            this.worldMap = new Tile[Config.GameConfig.GridMapY][];
            this.dummyBuildings = new List<Tile>();
            this.walkableTiles = new List<Tile>();
            this.nonWalkableTiles = new List<Tile>();

            for (int raw = 0; raw < Config.GameConfig.GridMapY; raw++)
            {
                this.worldMap[raw] = new Tile[Config.GameConfig.GridMapX];
                for (int column = 0; column < Config.GameConfig.GridMapX; column++)
                {
                    this.worldMap[raw][column] = new Tile(new Point(raw * Config.GameConfig.TileSize, column * Config.GameConfig.TileSize), 0, dummyMapTile, false,false);
                }
            }

            using (StreamReader reader = new StreamReader(@"MapTileData\map.txt"))
            {
                for (int y = 0; y < Config.GameConfig.GridMapY; y++)
                {
                    string line = reader.ReadLine();

                    for (int x = 0; x < Config.GameConfig.GridMapX; x++)
                    {
                        switch ((int)line[x])
                        {
                            case 48:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, new StreetTile(false), false, true);
                                this.NonWalkableTiles.Add(this.worldMap[y][x]);
                                break;
                            case 49:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, dummyMapTile, dummyMapTile.Walkable, false);
                                this.DummyBuildings.Add(this.worldMap[y][x]);
                                break;
                            case 50:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, parkTile, parkTile.Walkable, false);
                                this.WalkableTiles.Add(this.worldMap[y][x]);
                                break;
                            case 51:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, alleyTile, alleyTile.Walkable, false);
                                this.WalkableTiles.Add(this.worldMap[y][x]);
                                break;
                            case 52:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, new StreetTile(true), true, true);
                                this.NonWalkableTiles.Add(this.worldMap[y][x]);
                                break;
                            case 53:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, new StreetTile(true), true, true);
                                this.NonWalkableTiles.Add(this.worldMap[y][x]);
                                break;
                            case 58:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, waterTile, waterTile.Walkable, false);
                                break;
                            default:
                                this.worldMap[y][x] = new Tile(new Point(x * Config.GameConfig.TileSize, y * Config.GameConfig.TileSize), 0, waterTile, waterTile.Walkable, false);
                                break;
                        }
                    }
                }
            }
        }

        public static Map Instance
        {
            get
            {
                if (Map.instance == null)
                {
                    Map.instance = new Map();
                }
                return Map.instance;
            }
        }
    }
}

