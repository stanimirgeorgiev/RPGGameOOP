using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BGSurv
{
    public partial class CombatGUI : Form
    {
        private List<CombatPartyMember> playerPartyMembers;
        private CombatPartyMember enemyMember;
        private bool inCombat;
        private bool playerTurn;
        private List<ActiveSkill> activeSkills = new List<ActiveSkill>();
        private PlayerParty playerParty;
        private CombatPartyMember enemy;

        public CombatGUI()
        {
            InitializeComponent();
            playerPartyMembers = new List<CombatPartyMember>();
            inCombat = false;
            playerTurn = true;
        }

        public bool InCombat
        {
            get { return this.inCombat; }
            set { this.inCombat = value; }
        }

        public void StartCombat(PlayerParty playerParty, CombatPartyMember enemy)
        {
            this.playerParty = playerParty;

            this.enemyMember = enemy;

            if (!playerPartyMembers.Contains(playerParty.member1))
            {
                playerPartyMembers.Add(playerParty.member1);
            }

            if (playerParty.member2 != null)
            {
                if (playerParty.member2.health <= 0)
                {
                    playerParty.member2.health = 0;
                    partyPB2.Image = default(Image);
                    player2Health.Text = playerParty.member2.health.ToString();
                }
                else
                {
                    playerPartyMembers.Add(playerParty.member2);
                    partyPB2.Image = playerPartyMembers[1].img;
                    player2Health.Text = playerParty.member2.health.ToString();
                }
            }

            this.inCombat = true;
            if (playerParty.member1.health <= 0)
            {
                playerParty.member1.health = 0;
                partyPB1.Image = default(Image);
                player1Health.Text = playerParty.member1.health.ToString();
            }
            else
            {
                partyPB1.Image = playerPartyMembers[0].img;
                player1Health.Text = playerParty.member1.health.ToString();
            }

            this.enemy = enemy;
            enemyPB1.Image = enemyMember.img;
            enemyHealth.Text = enemy.health.ToString();

            //LoadSkillsForPlayer();
        }

        void OutputFlavourText(string text)
        {
            flavourTextBox.AppendText(text + "\r\n");
        }

        void LoadSkillsForPlayer()
        {
            cmbSkill.Items.Clear();
            for (int i = 0; i < 2; i++)
            {
                foreach (Skill s in playerPartyMembers[i].skills)
                {
                    cmbSkill.Items.Add(s.Name);
                }
            }



        }

        void ApplySkillDamage()
        {
            for (int x = 0; x < activeSkills.Count; x++)
            {
                var a = activeSkills[x];
                a.target.health -= a.skill.DamagePerTurn;
                a.remainingTurns--;

                OutputFlavourText(a.skill.Name + " did " + a.skill.DamagePerTurn + " damage!");

                if (a.remainingTurns == 0)
                    activeSkills.RemoveAt(x);
            }
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            //ApplySkillDamage();

            if (inCombat)
            {
                //
                if (playerTurn)
                {
                    //LoadSkillsForPlayer();
                    if (partyActionAttack.Checked)
                    {
                        for (int i = 0; i < playerPartyMembers.Count; i++)
                        {

                            //Damage done will vary 
                            int damage = playerPartyMembers[i].attackPower;

                            OutputFlavourText(playerPartyMembers[i].name + " attacked foe for " + damage);

                            enemyMember.health -= damage;
                            if (enemyMember.health < 0)
                            {
                                enemyHealth.Text = "0";
                            }
                            else
                            {
                                enemyHealth.Text = enemyMember.health.ToString();
                            }
                            Thread.Sleep(500);
                            Random rand = new Random();
                            int x = rand.Next(0, playerPartyMembers.Count - 1);
                            playerPartyMembers[x].health -= enemyMember.attackPower;
                            if (playerPartyMembers[x].health < 0)
                            {
                                if (x == 0)
                                {

                                    player1Health.Text = "0";
                                }
                                else
                                {
                                    player2Health.Text = "0";

                                }
                            }
                            else
                            {
                                if (x == 0)
                                {

                                    player1Health.Text = playerPartyMembers[x].health.ToString();
                                }
                                else
                                {
                                    player2Health.Text = playerPartyMembers[x].health.ToString();

                                }
                            }

                            OutputFlavourText("Player + " + playerPartyMembers[x].name + " hit for " + enemyMember.attackPower + " damage!");
                            inCombat = false;
                            foreach (CombatPartyMember c in playerPartyMembers)
                            {
                                if (c.health >= 0)
                                {
                                    inCombat = true;
                                }
                            }
                            if (inCombat == false)
                            {
                                OutputFlavourText("Player party defeated!");
                                ClearBattleForm();

                            }
                            else
                            {
                                playerTurn = true;
                            }
                        }
                    }
                    if (partyActionSkill.Checked)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            foreach (Skill s in playerPartyMembers[i].skills)
                            {
                                if (s.Name == cmbSkill.Text)
                                {
                                    ActiveSkill a = new ActiveSkill();
                                    a.skill = s;
                                    a.target = enemyMember;
                                    a.remainingTurns = s.Duration;
                                    activeSkills.Add(a);

                                    enemyMember.health -= s.InitialDamage;
                                    OutputFlavourText(playerPartyMembers[i].name + " cast " + s.Name + " for " +
                                                      s.InitialDamage);
                                }
                            }
                        }
                    }
                }

                //Exit battle if enemy is dead
                if (enemyMember.health <= 0)
                {
                    flavourTextBox.AppendText("\n" + "Enemy defeated!");
                    ClearBattleForm();
                    inCombat = false;
                }
            }
        }

        private void ClearBattleForm()
        {
            if (this.playerParty.member2 != null)
            {
                if (this.playerParty.member2.health <= 0)
                {
                    this.playerParty.member2 = null;
                    partyPB2.Image = default(Image);
                    player2Health.Text = "";
                }
            }
            if (this.playerParty.member1.health <= 0)
            {
                this.playerParty.member1.health = 0;
                partyPB1.Image = default(Image);
                player1Health.Text = playerParty.member1.health.ToString();
            }
            if (this.enemy.health <= 0)
            {
                this.enemy.health = 0;
                enemyPB1.Image = default(Image);
                enemyHealth.Text = this.enemy.health.ToString();
            }
            flavourTextBox.Text = "";
        }
    }

    public class CombatPartyMember
    {
        //
        public string name;

        public int health;
        public int attackPower;
        public Image img;
        public List<Skill> skills = new List<Skill>();

        //

        public CombatPartyMember(int health, int attackPower, Image img, string name)
        {
            this.health = health;
            this.attackPower = attackPower;
            this.img = img;
            this.name = name;

            //
            Skill s = new Skill();
            s.DamagePerTurn = 2;
            s.InitialDamage = 3;
            s.Duration = 1;
            s.Name = "Bleed";
            skills.Add(s);

            s.DamagePerTurn = 2;
            s.InitialDamage = 3;
            s.Duration = 1;
            s.Name = "Reed";
            skills.Add(s);

        }
    }

    //
    public class Skill
    {
        public int InitialDamage { get; set; }
        public int DamagePerTurn { get; set; }
        public int Duration { get; set; }
        public string Name { get; set; }



        private int initialDamage;
        private int damagePerTurn;
        private int duration;
        private string name;
    }

    //
    public class ActiveSkill
    {
        public Skill skill;
        public CombatPartyMember target;
        public int remainingTurns;
    }
}