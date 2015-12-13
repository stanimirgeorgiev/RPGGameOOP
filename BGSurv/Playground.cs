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
    public partial class Playground : Form
    {
        private Game game;
       
        
        public  Playground(string name, int age)
        {
            InitializeComponent();
            this.game = new Game(this, name, age);
            //this.game.Player = 
            
            
        }
        public Game Game { get; set; }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.game.HandleKeyPress(e);
        }
    }
}
