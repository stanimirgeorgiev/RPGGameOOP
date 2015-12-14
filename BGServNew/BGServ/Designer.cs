using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;
using BGServ;
using BulgarianReality.Humans;

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
            this.device.DrawImage(new Bitmap(@"images\DummyTile.png"), player.Location);

            //this.designer.Height = Config.GameConfig.TileSize;
            //this.designer.Width = Config.GameConfig.TileSize;
            this.designer.BackColor = Color.White;
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
                    device.DrawImage(map[y][x].Building.Image, map[y][x].Location);
                }
            }

            this.designer.Image = this.img;
        }
    }
}
