using BulgarianReality.Buildings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGServ
{
    public class Collision
    {
        private Action action;

        public Collision()
        {
           
        }
        public bool DetectColisionWithBuilding(Point check)
        {
            if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Walkable)
            {
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Bank)
                {
                    this.action = new Action("bank");
                    
                }
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Hospital)
                {
                    this.action = new Action("hospital");
                    
                }
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Office)
                {
                    this.action = new Action("office");
                    
                }
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Supermarket)
                {
                    this.action = new Action("supermarket");

                }
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Coffee)
                {
                    this.action = new Action("coffee");

                }
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Restaurant)
                {
                    this.action = new Action("restaurant");

                }
                if (Map.Instance.WorldMap[check.Y / 40][check.X / 40].Building is Restaurant)
                {
                    this.action = new Action("police");

                }



                return true;
                
                
            }
            return false;
        }
    }
}
