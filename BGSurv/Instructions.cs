using System;
using System.Collections.Generic;
using System.Drawing;
using BGSurv.Map;

namespace BGSurv
{
    class Instructions
    {
        public void ExectueInstruction(List<string> instructions)
        {
            if (instructions.Count > 0)
            {
                switch (instructions[0].Substring(1, 4))
                {
                    case "NEWP":

                        Game.Instance().PlayerParty.member2 = new CombatPartyMember(int.Parse(instructions[1]), int.Parse(instructions[2]),
                            new Bitmap(instructions[3]), instructions[4]);
                        instructions.RemoveRange(0, 5);
                        ExectueInstruction(instructions);
                        break;

                    case "REMV":
                        Game.Instance().friendlyNPCs.Remove((WorldMapSprite)Game.Instance().textBoxReader.sender);
                        instructions.RemoveRange(0, 1); 
                        ExectueInstruction(instructions)    ;
                        break;
                }
            }
        }
    }
}
