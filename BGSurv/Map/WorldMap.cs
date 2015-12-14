
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BGSurv.Player;

namespace BGSurv.Map
{
    public class WorldMap
    {
        private static WorldMap instance = null;
        public Image mapImage;
        public Tile[][] mapTiles;
        private Form form;

        public struct Tile
        {
            public Image img;
            public Point loc;
            public bool walkable;
            public Building building;
            public Human character;
        }

        public WorldMap(Form form)
        {
            this.form = form;
        }

        public void LoadMap(int x1, int y1)
        {
            mapTiles = new Tile[16][];
            StreamReader reader = new StreamReader(@"MapTileData\map.txt");

            int y = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                int lenght = line.Length;
                Tile t = new Tile();
                for (int x = 0; x < lenght; x++)
                {
                    t.loc = new Point(x * 40, y * 40);
                    switch (line[x].ToString())
                    {
                        case "0":
                            t.img = new Bitmap("StreetTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                        case "1":
                            t.img = new Bitmap("BuildingTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                        case "2":
                            t.img = new Bitmap("GrassTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                        case "3":
                            t.img = new Bitmap("AllayTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                        case "4":
                            t.img = new Bitmap("ZebraHTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                        case "5":
                            t.img = new Bitmap("ZebraVTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                        case "6":
                            t.img = new Bitmap("GrassTile.png");
                            t.walkable = true;
                            t.building = new Building();
                            break;
                    }
                    mapTiles[x][y] = t;
                }
                y++;
            }
            reader.Close();
        }

        public void DrawMap(Graphics device, Point location)
        {
            int startX = location.X;
            int endX = location.X;

            int startY = location.Y;
            int endY = location.Y;
            List<Tile> localMap = new List<Tile>();
            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    localMap.Add(mapTiles[x][y]);
                }
            }
            foreach (Tile t in localMap)
            {
                device.DrawImage(t.img, t.loc);
            }
        }

        public bool GetWalkableAt(Point loc)
        {
            foreach (Tile[] tile in mapTiles)
            {
                foreach (Tile t in tile)
                {

                    if (t.loc == loc)
                    {
                        if (t.walkable)
                            return true;
                    }
                }
            }
            return false;
        }

        public void LoadNewMap(int xMove, int yMove, Human player)
        {
            Point newLocation = player.Location;
            newLocation.X += xMove;
            newLocation.Y += yMove;
            WorldMap.Instance().LoadMap(newLocation.X, newLocation.Y);
            LoadPlayers load = new LoadPlayers();
            load.LoadMonstersOnMap();
            load.LoadFriendlyNPCsOnMap();
        }
        public static WorldMap Instance()
        {
            if (WorldMap.instance == null)
            {
                WorldMap.instance = new WorldMap(Game.Instance().GameForm);
            }
            return WorldMap.instance;
        }

        public void DrawMap(Graphics device)
        {
            throw new System.NotImplementedException();
        }
    }
}
