using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGSurv.Map;

namespace BGSurv
{
    public class Draw
    {
        private static Draw instance= null;
        private PictureBox worldMapSpritePb;

        private Draw()
        {
            
        }
        private Form gameForm = Game.Instance().GameForm;
        public static Graphics Device { get; set; }
        public void Render()
        {

            Image img = new Bitmap(this.gameForm.Width, this.gameForm.Height);
            Device = Graphics.FromImage(img);

            WorldMap.Instance().DrawMap(Device, Game.Instance().Character.Location);
            foreach (var character in Game.Instance().Characters)
            {
                //check if monster is alive before drawing
                if (character.alive)
                    character.Draw(Device);
            }

            //if (textBoxReader.open)
            //{
            //    device.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 300, 400, 70));
            //    device.DrawString(textBoxReader.currentText, new Font("arial", 10),
            //        new SolidBrush(Color.White), new Point(5, 305));
            //}

            worldMapSpritePb.Image = img;
        }

        public static Draw Instance()
        {
            if (Draw.instance == null)
            {
                Draw.instance = new Draw();
            }
            return Draw.instance;
        }
    }
}
