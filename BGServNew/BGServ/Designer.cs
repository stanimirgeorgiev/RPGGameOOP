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
        private Tile[][] currentMap;
        private Image img = new Bitmap(Game.Instance.GameForm.Width, Game.Instance.GameForm.Height);
        private Graphics device;

        public Designer()
        {
            this.designer = new PictureBox();
            this.designer.Parent = Game.Instance.GameForm;
            this.device = Graphics.FromImage(this.img);
        }


        public void DrawPlayer(Human player)
        {

            this.device.DrawImage(player.Image, player.Location);

            this.designer.Height = Config.GameConfig.TileSize;
            this.designer.Width = Config.GameConfig.TileSize;
            this.designer.BackColor = Color.Transparent;
            this.designer.Image = this.img;

        }

        public void DrawMap(Tile[][] map)
        {
            for (int y = 0; y < Config.GameConfig.MapY; y++)
            {
                
                for (int x = 0; x < Config.GameConfig.MapX; x++)
                {
                    device.DrawImage(map[y][x].Building.Image, map[y][x].Location);
                }
            }
            this.designer.Image = this.img;
        }
    }
}
