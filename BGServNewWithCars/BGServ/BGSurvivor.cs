using BulgarianReality.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BGServ
{
    public partial class BGSurvivor : Form
    {
        private string firstname;
        private string lastname;
        private int age;
        private Gender gender;
        private string avatar;
        private Playground playgroung;

        public BGSurvivor()
        {
            InitializeComponent();
            
        }
        public void ChekStartInfo()
        {
            // first last name
            if(!string.IsNullOrWhiteSpace(this.textBox3.Text))
            {
                this.firstname = this.textBox3.Text;
                
            }
            else
            {
                MessageBox.Show("Firstname is required.");
                
            }
            if (!string.IsNullOrWhiteSpace(this.textBox1.Text))
            {
                this.lastname = this.textBox1.Text;
                
            }
            else
            {
                MessageBox.Show("Lastname is required.");
                
            }
            // gender
            if (this.radioButton1.Checked == true)
            {
                this.gender = Gender.Male;
                
            }
            else if (this.radioButton3.Checked == true)
            {
                this.gender = Gender.Female;
                
            }
            else if (this.radioButton2.Checked == true)
            {
                this.gender = Gender.Other;
                
            }
            else
            {
                MessageBox.Show("Gender is required.");
                
            }
            // age
            if(string.IsNullOrEmpty(this.comboBox1.Text))
            {
                this.age = int.Parse(this.comboBox1.Text);
                
            }
            // picture avatar 
            if(this.radioButton4.Checked == true)
            {
                this.avatar = @"images\Avatar2.jpg";
                
            }
            else if(this.radioButton5.Checked == true)
            {
                this.avatar = @"images\womanAvatar.png";
                
            }
            else
            {
                MessageBox.Show("Picture is required");
                
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ChekStartInfo();
            
                this.Hide();
                this.playgroung = new Playground(this.firstname, this.lastname, this.age,this.gender, this.avatar);
                this.playgroung.ShowDialog();
                this.Close();
            
            
            
        }
    }
}
