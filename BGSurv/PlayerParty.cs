using System.Drawing;
using BGSurv.Map;

namespace BGSurv
{
    public class PlayerParty
    {
        public WorldMapSprite PartySprite { get; set; }
             public WorldMapSprite partySprite;
            public CombatPartyMember member1;
            public CombatPartyMember member2;
            //member2, 3...

            public PlayerParty(Point location, Image image, int ID,
                CombatPartyMember member1)
            {
                //load in character images from save file eventually
                this.PartySprite = new WorldMapSprite(location, image, ID);
                this.member1 = member1;
            }
        }
}