using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulgarianReality.Humans;
using BulgarianReality.Humans.Workers;

namespace BGServ
{
    public partial class Playground : Form
    {
        public Playground()
        {
            InitializeComponent();
            Game.SetForm(this, new Developer("Pesho", "Peshev", 25, BulgarianReality.Enums.Gender.Male, new BulgarianReality.Items.Belongings.Wallet(0), new Point(Config.GameConfig.PlayerStartX, Config.GameConfig.PlayerStartY), new Bitmap(@"images\sprite.png")));
            Game.Instance.Run();
        }
    }
}
