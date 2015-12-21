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
        private BGSurvEvent events;
        private Timer timer = new Timer();
        private Timer realTimer = new Timer();
        private Random rand = new Random();
        public Playground()
        {
            InitializeComponent();
            Game.SetForm(this, new Developer(1, "Pesho", "Peshev", 25, BulgarianReality.Enums.Gender.Male, new BulgarianReality.Items.Belongings.Wallet(100), new Point(Config.GameConfig.PlayerStartX, Config.GameConfig.PlayerStartY), new Bitmap(@"images\sprite.png")));
            Game.Instance.Run();
            this.events = new BGSurvEvent();
            timer.Tick += new EventHandler(timer1_Tick);
           
            timer.Enabled = true;
            timer.Interval = Config.GameConfig.TimerTick;
            timer.Start();
            realTimer.Tick += new EventHandler(timer2_Tick);

            realTimer.Enabled = true;
            realTimer.Interval = Config.GameConfig.RealTick;
            realTimer.Start();
            
        }
        //private void Playground_KeyDown(object sender, KeyEventArgs e)
        //{
        //    this.events.HandleKeyPress(e);
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {

            Game.Instance.MoveBots();
            this.label3.Text = Game.Instance.Player.Health.ToString();
        }

        private void Playground_KeyDown_1(object sender, KeyEventArgs e)
        {
            this.events.HandleKeyPress(e);
            if (Game.Instance.Player.InAction)
            {
                
                if(Game.Instance.Player.Oponent == null)
                {
                    this.pictureBox1.Load(Game.Instance.Player.CollisionImage);
                    this.label10.Text = Game.Instance.Player.MeetMsg;
                    this.groupBox2.Text = Game.Instance.Player.BuilDingName;
                    
                }
                else
                {
                    this.pictureBox1.Load(Game.Instance.Player.CollisionImage);
                   // this.label10.Text = Game.Instance.Player.Oponent.Firstname + " " + Game.Instance.Player.Oponent.Lastname;
                    this.groupBox2.Text = Game.Instance.Player.Oponent.Firstname + " " + Game.Instance.Player.Oponent.Lastname;
                    this.label10.Text = Game.Instance.Player.Oponent.MeetMsg;
                }
                Game.Instance.Player.Oponent = null;
                
           }
            else
            {
                this.pictureBox1.Load(@"images\default.png");
                this.groupBox2.Text = "";
                this.label10.Text = "";
            }
            Game.Instance.Player.InAction = false;
            
            
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.label9.Text = Game.Instance.Player.Joy.ToString();
            this.label4.Text = Game.Instance.Player.Wallet.Balance.ToString();
        }

       

    }
}
