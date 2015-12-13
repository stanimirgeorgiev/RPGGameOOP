using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace BGSurv
{
    using Config;
    public  class Game
    {
        Form gameForm;
        CombatGUI combatGUI;
        WorldMap worldMap;
        PlayerParty playerParty;
        PictureBox worldMapSpritePb;

        //
        TextBoxReader textBoxReader;

        List<WorldMapMonster> worldMapMonsters;
        //
        List<WorldMapSprite> friendlyNPCs;

        WorldMapMonster monsterInCombat;
        bool inCombat = false;

        int playerStartX;
        int playerStartY;

        public PlayerParty Player { get; set; }

        public Game(Form form, string name, int age)
        {

            this.Player = this.playerParty;

            gameForm = form;
            //TODO Constant
            gameForm.BackColor = Color.White;

            worldMap = new WorldMap(gameForm);
            worldMapMonsters = new List<WorldMapMonster>();
            
            //TODO player start start from home

            playerStartX = PlayerConfig.PlayerStartX;
            playerStartY = PlayerConfig.PlayerStartY;

            //
            friendlyNPCs = new List<WorldMapSprite>();

            //TODO implementing random NPCs and other humans
            friendlyNPCs.Add(new WorldMapSprite(new Point(40, 120), new Bitmap("Rogue.png"), 1));
            
            friendlyNPCs[0].textFilename = "rogueIntro";

            LoadNewMap(0, 0);

            //
            textBoxReader = new TextBoxReader();

            //combatGUI = new CombatGUI();
            //combatGUI.Visible = true;

            inCombat = false;

            //Add combat party members for this class
            playerParty = new PlayerParty(new Point(80, 0), new Bitmap("PlayerPartySprite.png"), 1,
                new CombatPartyMember(50, 5, new Bitmap("PlayerPartySprite.png"), "Link"),name, age);

            worldMapSpritePb = new PictureBox();
            worldMapSpritePb.Width = gameForm.Width;
            worldMapSpritePb.Height = gameForm.Height;
            worldMapSpritePb.BackColor = Color.Transparent;
            worldMapSpritePb.Parent = gameForm;

            Draw();
        }

        //
        void LoadNewMap(int xMove, int yMove)
        {
            playerStartX += xMove;
            playerStartY += yMove;
            worldMap.LoadMap(playerStartX + " " + playerStartY);

            LoadMonstersOnMap();
            LoadFriendlyNPCsOnMap();
        }

        //
        void LoadMonstersOnMap()
        {
            worldMapMonsters.Clear();

            StreamReader reader = new StreamReader(@"MapEntityData\" + playerStartX + " " + playerStartY + ".txt");

            int y = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x].ToString() == "1")
                    {
                        //
                        worldMapMonsters.Add(new WorldMapMonster(new Point(x * 40, y * 40), new Bitmap("MonsterSprite.png"),
                            0, new CombatPartyMember(30, 5, new Bitmap("GoblinCombatSprite.png"), "Goblin")));
                    }
                }
                y++;
            }
            reader.Close();
        }

        void LoadFriendlyNPCsOnMap()
        {
            //friendlyNPCs.Clear();
            //Load friendly NPCs from file
        }

        public void HandleKeyPress(KeyEventArgs e)
        {
            //Determine if player can move
            if (!inCombat)
            {
                //
                if (textBoxReader.open)
                {
                    if (e.KeyCode == Keys.Enter)
                        textBoxReader.Next();

                    if (textBoxReader.instructions.Count > 0)
                        ExectueInstruction(textBoxReader.instructions);
                }
                else
                {
                    //
                    Point p = new Point(0, 0);

                    if (e.KeyCode == Keys.Left) { p = new Point(-40, 0); }
                    if (e.KeyCode == Keys.Right) { p = new Point(40, 0); }
                    if (e.KeyCode == Keys.Up) { p = new Point(0, -40); }
                    if (e.KeyCode == Keys.Down) { p = new Point(0, 40); }

                    //
                    Point potentialMove = new Point(p.X + playerParty.partySprite.location.X,
                        p.Y + playerParty.partySprite.location.Y);


                    if (worldMap.GetWalkableAt(potentialMove))
                    {
                        playerParty.partySprite.Move(p.X, p.Y);
                    }
                    else
                    {
                        //Load new map if possible
                        if (potentialMove.X > 40 * 9)
                        {
                            LoadNewMap(1, 0);
                            playerParty.partySprite.Move(-360, 0);
                        }
                        if (potentialMove.X < 0)
                        {
                            LoadNewMap(-1, 0);
                            playerParty.partySprite.Move(360, 0);
                        }
                        if (potentialMove.Y < 0)
                        {
                            LoadNewMap(0, -1);
                            playerParty.partySprite.Move(0, 360);
                        }
                        if (potentialMove.Y > 40 * 8)
                        {
                            LoadNewMap(0, 1);
                            playerParty.partySprite.Move(0, -320);
                        }
                    }
                }

            }
            else
            {
                //Use monsterInCombat variable to remove correct sprite
                //If the combat GUI has exited combat, remove our enemy sprite
                if (!combatGUI.InCombat)
                {
                    monsterInCombat.alive = false;
                    KillMonsterInList(monsterInCombat);
                    inCombat = false;
                }
            }

            DetectCollision();
            Draw();
        }

        //Kill this monster in the list
        void KillMonsterInList(WorldMapMonster m1)
        {
            foreach (WorldMapMonster m in worldMapMonsters)
            {
                if (m == m1)
                {
                    m.alive = false;
                }
            }
        }

        //
        public void DetectCollision()
        {
            foreach (WorldMapMonster m in worldMapMonsters)
            {
                //Check if monster is alive before detecting collision
                if (m.alive && playerParty.partySprite.location == m.location)
                {
                    //Create a reference to monster in combat with
                    monsterInCombat = m;
                    combatGUI.StartCombat(playerParty, monsterInCombat.member);
                    inCombat = true;
                }
            }
            foreach (WorldMapSprite m in friendlyNPCs)
            {
                //Check if NPC is alive before detecting collision
                if (playerParty.partySprite.location == m.location)
                {
                    playerParty.partySprite.location.X += 40;
                    if (m.textFilename != "")
                    {
                        textBoxReader.OpenText(m.textFilename, m);
                    }
                }
            }
        }

        void Draw()
        {
            Graphics device;
            Image img = new Bitmap(gameForm.Width, gameForm.Height);
            device = Graphics.FromImage(img);

            worldMap.DrawMap(device);
            playerParty.partySprite.Draw(device);

            foreach (WorldMapMonster m in worldMapMonsters)
            {
                //check if monster is alive before drawing
                if (m.alive)
                    m.Draw(device);
            }

            //
            foreach (WorldMapSprite m in friendlyNPCs)
            {
                m.Draw(device);
            }

            if (textBoxReader.open)
            {
                device.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 300, 400, 70));
                device.DrawString(textBoxReader.currentText, new Font("arial", 10),
                    new SolidBrush(Color.White), new Point(5, 305));
            }

            worldMapSpritePb.Image = img;
        }

        //
        public void ExectueInstruction(List<string> instructions)
        {
            if (instructions.Count > 0)
            {
                switch (instructions[0].Substring(1, 4))
                {
                    case "NEWP":
                        
                        playerParty.member2 = new CombatPartyMember(int.Parse(instructions[1]), int.Parse(instructions[2]),
                            new Bitmap(instructions[3]), instructions[4]);
                        instructions.RemoveRange(0, 5);
                        ExectueInstruction(instructions);
                        break;

                    case "REMV":
                        friendlyNPCs.Remove((WorldMapSprite)textBoxReader.sender);
                        instructions.RemoveRange(0, 1);
                        ExectueInstruction(instructions);
                        break;
                }
            }
        }
    }

    public class WorldMap
    {
        public Image mapImage;
        public List<Tile> mapTiles;

        public struct Tile
        {
            public Image img;
            public Point loc;
            public bool walkable;
        }

        public WorldMap(Form form)
        {
            mapTiles = new List<Tile>();
        }

        public void LoadMap(string mapName)
        {
            mapTiles.Clear();
            StreamReader reader = new StreamReader(@"MapTileData\" + mapName + ".txt");

            int y = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                for (int x = 0; x < line.Length; x++)
                {
                    Tile t = new Tile();
                    t.loc = new Point(x * 40, y * 40);

                    if (line[x].ToString() == "1")
                    {
                        t.img = new Bitmap("GrassTile.png");
                        t.walkable = true;
                    }
                    if (line[x].ToString() == "0")
                    {
                        t.img = new Bitmap("WaterTile.png");
                        t.walkable = false;
                    }

                    mapTiles.Add(t);
                }

                y++;
            }

            reader.Close();
        }

        public void DrawMap(Graphics device)
        {
            foreach (Tile t in mapTiles)
            {
                device.DrawImage(t.img, t.loc);
            }
        }

        public bool GetWalkableAt(Point loc)
        {
            foreach (Tile t in mapTiles)
            {
                if (t.loc == loc)
                {
                    if (t.walkable)
                        return true;
                }
            }

            return false;
        }
    }

    public class WorldMapSprite
    {
        public Point location;
        public Image image;
        public int ID;
        public string textFilename = "";

        public WorldMapSprite(Point location, Image image, int ID)
        {
            this.location = location;
            this.image = image;
            this.ID = ID;
        }

        public void Draw(Graphics device)
        {
            device.DrawImage(image, location);
        }

        public void Move(int x, int y)
        {
            location.X += x;
            location.Y += y;
        }
    }

    public class WorldMapMonster : WorldMapSprite
    {
        public bool isStatic;
        public bool alive;
        public CombatPartyMember member;

        public WorldMapMonster(Point location, Image image, int ID, CombatPartyMember member)
            : base(location, image, ID)
        {
            this.member = member;
            isStatic = true;
            alive = true;
            //Loot loot;
        }
    }

    public class PlayerParty
    {
        public WorldMapSprite partySprite;
        public CombatPartyMember member1;
        public CombatPartyMember member2;

        private string name;
        private int age;
        //member2, 3...

        public PlayerParty(Point location, Image image, int ID,
            CombatPartyMember member1, string name, int age)
        {
            //load in character images from save file eventually
            partySprite = new WorldMapSprite(location, image, ID);
            this.member1 = member1;
            this.age = age;
            this.name = name;
        }
    }

    //
    public class TextBoxReader
    {
        public bool open;
        public string currentText;
        private List<string> text;
        private int index;
        public object sender;

        public List<string> instructions;

        public void OpenText(string name, object sender)
        {
            this.sender = sender;
            open = true;
            StreamReader reader = new StreamReader(@"Text\" + name + ".txt");
            text = new List<string>();
            index = 0;

            instructions = new List<string>();

            //read all the text for this string
            while (!reader.EndOfStream)
            {
                text.Add(reader.ReadLine());
            }

            Next();

            //remember to close
            reader.Close();
        }

        public void Next()
        {
            currentText = text[index];

            string i = currentText[0].ToString();

            //Add instructions to list to be executed
            if (string.Equals(i, "!"))
            {
                instructions.Clear();

                while (index < text.Count)
                {
                    instructions.Add(text[index]);
                    index++;
                }
                open = false;
            }

            index++;
        }
    }

}
