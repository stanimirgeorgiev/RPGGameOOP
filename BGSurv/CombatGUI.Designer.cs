namespace BGSurv
{
    partial class CombatGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonAttack = new System.Windows.Forms.Button();
            this.partyActionAttack = new System.Windows.Forms.CheckBox();
            this.partyActionSkill = new System.Windows.Forms.CheckBox();
            this.enemyAttackTimer = new System.Windows.Forms.Timer(this.components);
            this.cmbSkill = new System.Windows.Forms.ComboBox();
            this.flavourTextBox = new System.Windows.Forms.TextBox();
            this.partyPB1 = new System.Windows.Forms.PictureBox();
            this.partyPB2 = new System.Windows.Forms.PictureBox();
            this.enemyPB1 = new System.Windows.Forms.PictureBox();
            this.player1Health = new System.Windows.Forms.TextBox();
            this.player2Health = new System.Windows.Forms.TextBox();
            this.enemyHealth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.partyPB1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.partyPB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAttack
            // 
            this.buttonAttack.Location = new System.Drawing.Point(230, 374);
            this.buttonAttack.Name = "buttonAttack";
            this.buttonAttack.Size = new System.Drawing.Size(273, 80);
            this.buttonAttack.TabIndex = 0;
            this.buttonAttack.Text = "ATTACK";
            this.buttonAttack.UseVisualStyleBackColor = true;
            this.buttonAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // partyActionAttack
            // 
            this.partyActionAttack.Location = new System.Drawing.Point(12, 321);
            this.partyActionAttack.Name = "partyActionAttack";
            this.partyActionAttack.Size = new System.Drawing.Size(104, 24);
            this.partyActionAttack.TabIndex = 9;
            this.partyActionAttack.Text = "Attack";
            // 
            // partyActionSkill
            // 
            this.partyActionSkill.AutoSize = true;
            this.partyActionSkill.Location = new System.Drawing.Point(12, 351);
            this.partyActionSkill.Name = "partyActionSkill";
            this.partyActionSkill.Size = new System.Drawing.Size(45, 17);
            this.partyActionSkill.TabIndex = 1;
            this.partyActionSkill.Text = "Skill";
            this.partyActionSkill.UseVisualStyleBackColor = true;
            // 
            // cmbSkill
            // 
            this.cmbSkill.Location = new System.Drawing.Point(12, 374);
            this.cmbSkill.Name = "cmbSkill";
            this.cmbSkill.Size = new System.Drawing.Size(121, 21);
            this.cmbSkill.TabIndex = 8;
            // 
            // flavourTextBox
            // 
            this.flavourTextBox.Location = new System.Drawing.Point(230, 271);
            this.flavourTextBox.Multiline = true;
            this.flavourTextBox.Name = "flavourTextBox";
            this.flavourTextBox.Size = new System.Drawing.Size(273, 97);
            this.flavourTextBox.TabIndex = 4;
            // 
            // partyPB1
            // 
            this.partyPB1.Location = new System.Drawing.Point(15, 84);
            this.partyPB1.Name = "partyPB1";
            this.partyPB1.Size = new System.Drawing.Size(77, 110);
            this.partyPB1.TabIndex = 7;
            this.partyPB1.TabStop = false;
            // 
            // partyPB2
            // 
            this.partyPB2.Location = new System.Drawing.Point(142, 128);
            this.partyPB2.Name = "partyPB2";
            this.partyPB2.Size = new System.Drawing.Size(100, 66);
            this.partyPB2.TabIndex = 5;
            this.partyPB2.TabStop = false;
            // 
            // enemyPB1
            // 
            this.enemyPB1.Location = new System.Drawing.Point(343, 84);
            this.enemyPB1.Name = "enemyPB1";
            this.enemyPB1.Size = new System.Drawing.Size(69, 110);
            this.enemyPB1.TabIndex = 7;
            this.enemyPB1.TabStop = false;
            // 
            // player1Health
            // 
            this.player1Health.Location = new System.Drawing.Point(15, 223);
            this.player1Health.Name = "player1Health";
            this.player1Health.Size = new System.Drawing.Size(107, 20);
            this.player1Health.TabIndex = 6;
            // 
            // player2Health
            // 
            this.player2Health.Location = new System.Drawing.Point(142, 223);
            this.player2Health.Name = "player2Health";
            this.player2Health.Size = new System.Drawing.Size(107, 20);
            this.player2Health.TabIndex = 6;
            // 
            // pnemyHealth
            // 
            this.enemyHealth.Location = new System.Drawing.Point(343, 223);
            this.enemyHealth.Name = "enemyHealth";
            this.enemyHealth.Size = new System.Drawing.Size(107, 20);
            this.enemyHealth.TabIndex = 6;
            // 
            // CombatGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 466);
            this.Controls.Add(this.enemyHealth);
            this.Controls.Add(this.player2Health);
            this.Controls.Add(this.player1Health);
            this.Controls.Add(this.enemyPB1);
            this.Controls.Add(this.partyPB2);
            this.Controls.Add(this.partyPB1);
            this.Controls.Add(this.flavourTextBox);
            this.Controls.Add(this.cmbSkill);
            this.Controls.Add(this.partyActionSkill);
            this.Controls.Add(this.partyActionAttack);
            this.Controls.Add(this.buttonAttack);
            this.Name = "CombatGUI";
            this.Text = "CombatGUI";
            ((System.ComponentModel.ISupportInitialize)(this.partyPB1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.partyPB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPB1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAttack;
        private System.Windows.Forms.CheckBox partyActionAttack;
        private System.Windows.Forms.CheckBox partyActionSkill;
        private System.Windows.Forms.Timer enemyAttackTimer;
        private System.Windows.Forms.ComboBox cmbSkill;
        private System.Windows.Forms.TextBox flavourTextBox;
        private System.Windows.Forms.PictureBox partyPB1;
        private System.Windows.Forms.PictureBox partyPB2;
        private System.Windows.Forms.PictureBox enemyPB1;
        private System.Windows.Forms.TextBox player1Health;
        private System.Windows.Forms.TextBox player2Health;
        private System.Windows.Forms.TextBox enemyHealth;

    }
}