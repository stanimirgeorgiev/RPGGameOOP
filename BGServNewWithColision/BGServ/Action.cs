using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGServ
{
    public class Action
    {
        public Action(string action)
        {
            switch(action)
            {
                case "joy":
                    IncreaseJoy();
                    break;
                case "cancel": Game.Instance.Player.InAction = false;
                    break;
            }
        }
        private void IncreaseJoy()
        {
            Game.Instance.Player.Joy += 10;
           
        }
    }
}
