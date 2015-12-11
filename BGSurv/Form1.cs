using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGSurv
{
    public partial class Form1 : Form
    {
        public Game game;

        public  Form1()
        {
            InitializeComponent();
            this.game = new Game(this);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            this.game.HandleKeyPress(e);

        }
    }
}
