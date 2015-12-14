using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulgarianReality.Humans;

namespace WindowsFormsApplication1
{
    class Disigner
    {
        private PictureBox designer;
        private Graphics picture;
        public Disigner()
        {
            this.designer = new PictureBox();
            
        }
        public void DrawPlayer(Human player)
        {
            //this.designer = player.Image;
        }
    }
}
