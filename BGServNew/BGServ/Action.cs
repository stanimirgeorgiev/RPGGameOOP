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
                
                    
               
                case "bank": this.IncreaseMoneyInBank();
                    break;
                case "hospital": this.IncreaseHealthInHispitam();
                    break;
                case "office": this.WorkInOffice();
                    break;
                case "supermarket": this.ShopInSuperMarket();
                    break;
                case "coffee": this.CoffeTime();
                    break;
                case "restaurant": this.RestaurantTime();
                    break;
                case "police": this.PoliceStaion();
                    break;
                default :
                    break;
            }
        }
       
        private void IncreaseMoneyInBank()
        {
            Game.Instance.Player.Wallet.Balance += 10;
        }
        private void IncreaseHealthInHispitam()
        {
            if(Game.Instance.Player.Wallet.Balance > 20)
            {
                Game.Instance.Player.Health += 40;
                Game.Instance.Player.Wallet.Balance -= 20;
            }
        }
        private void WorkInOffice()
        {
            Game.Instance.Player.Wallet.Balance += 80;
        }
        private void ShopInSuperMarket()
        {
            if(Game.Instance.Player.Wallet.Balance > 40)
            {
                Game.Instance.Player.Health += 60;
                Game.Instance.Player.Wallet.Balance -= 40;
            }
        }
        private void CoffeTime()
        {
            Game.Instance.Player.Joy += 30;
        }
        private void RestaurantTime()
        {
            if(Game.Instance.Player.Wallet.Balance >50)
            {
                Game.Instance.Player.Wallet.Balance -= 50;
                Game.Instance.Player.Health += 40;
                Game.Instance.Player.Joy += 20;
            }
        }
        private void PoliceStaion()
        {
            Game.Instance.Player.Joy += 35;
        }
    }
}
