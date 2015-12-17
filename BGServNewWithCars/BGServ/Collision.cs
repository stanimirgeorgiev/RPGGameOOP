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
        public void DetectColisionWithBuilding(Point check)
        {
            
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Bank)
                {
                    this.action = new Action("bank");
                    
                }
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Hospital)
                {
                    this.action = new Action("hospital");
                   

                }
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Office)
                {
                    this.action = new Action("office");
                    

                }
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Supermarket)
                {
                    this.action = new Action("supermarket");
                    

                }
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Coffee)
                {
                    this.action = new Action("coffee");
                   

                }
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Restaurant)
                {
                    this.action = new Action("restaurant");
                    

                }
                if (Map.Instance.WorldMap[check.Y / Config.GameConfig.TileSize][check.X / Config.GameConfig.TileSize].Building is Restaurant)
                {
                    this.action = new Action("police");
                    

                }
                
            }
          
    }
}
