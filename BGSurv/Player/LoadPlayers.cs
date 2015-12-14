using System.Drawing;
using System.IO;

using BGSurv.Map;

namespace BGSurv.Player
{
    public class LoadPlayers
    {
        public void LoadMonstersOnMap()
        {
            Game.Instance().worldMapMonsters.Clear();

            StreamReader reader = new StreamReader(@"MapEntityData\map.txt");

            int y = 0;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x].ToString() == "1")
                    {
                        //
                        Game.Instance().worldMapMonsters.Add(new Human(new Point(x * 40, y * 40), new Bitmap("MonsterSprite.png"),
                            0, new CombatPartyMember(30, 5, new Bitmap("GoblinCombatSprite.png"), "Goblin")));
                    }
                }
                y++;
            }
            reader.Close();
        }

        public void LoadFriendlyNPCsOnMap()
        {
            //friendlyNPCs.Clear();
            //Load friendly NPCs from file
        }
    }
}
