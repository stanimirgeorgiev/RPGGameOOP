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
    public partial class Survive : Form
    {
        
        private Playground playground;

        public Survive()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.playground = new Playground();
            this.playground.ShowDialog();
            this.Close();
        }
        //public PlayerParty CreateCharacter(string name,string picUrl, )
        
    }
}
