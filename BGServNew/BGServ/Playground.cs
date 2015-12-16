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
        BindingSource bs = new BindingSource();
        private BGSurvEvent events;
        private Timer timer = new Timer();
        private Random rand = new Random();
        public Playground()
        {
            InitializeComponent();
            Game.SetForm(this, new Developer(-1, "Pesho", "Peshev", 25, BulgarianReality.Enums.Gender.Male, new BulgarianReality.Items.Belongings.Wallet(0), new Point(Config.GameConfig.PlayerStartX, Config.GameConfig.PlayerStartY), new Bitmap(@"images\sprite.png")));
            Game.Instance.Run();
            bs.DataSource = Game.Instance.Player;
            playerHealth.DataBindings.Add(new Binding("Text", bs, "Health", false, DataSourceUpdateMode.OnPropertyChanged));

            this.events = new BGSurvEvent();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Enabled = true;
            timer.Interval = Config.GameConfig.TimerTick;
            timer.Start();
        }
        private void Playground_KeyDown(object sender, KeyEventArgs e)
        {
            this.events.HandleKeyPress(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Game.Instance.MoveBots();
        }
    }
}
