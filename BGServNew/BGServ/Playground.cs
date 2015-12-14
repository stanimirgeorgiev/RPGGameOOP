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

namespace WindowsFormsApplication1
{
    public partial class Playground : Form
    {
        public Playground()
        {
            InitializeComponent();
            Game.SetForm(this, new Human());
            Game.Instance.Run();
        }
    }
}
