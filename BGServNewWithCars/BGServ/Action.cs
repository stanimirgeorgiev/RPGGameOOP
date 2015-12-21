using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGServ
{
    public class Action
    {
        private Dictionary<string, string> msgs;

        public Action(string action)
        {
            this.msgs = new Dictionary<string, string>();
            switch(action)
            {
                case "joy":
                    IncreaseJoy();
                    break;
                case "cancel": Game.Instance.Player.InAction = false;
                    break;
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
                case "police": this.Police();
                    break;
                case "Developer": this.DeveloperMeet();
                    break;
                default:
                    break;
            }
            this.SeedMsg();
        }
        public Dictionary<string, string> Msgs { get { return this.msgs; } }

        private void IncreaseJoy()
        {
            Game.Instance.Player.Joy += 10;
           
        }
        private void IncreaseMoneyInBank()
        {
            Game.Instance.Player.Wallet.Balance += 10;
        }
        private void IncreaseHealthInHispitam()
        {
            if (Game.Instance.Player.Wallet.Balance > 20)
            {
                Game.Instance.Player.Health += 35;
                Game.Instance.Player.Wallet.Balance -= 20;
            }
        }
        private void WorkInOffice()
        {
            Game.Instance.Player.Wallet.Balance += 80;
        }
        private void ShopInSuperMarket()
        {
            if (Game.Instance.Player.Wallet.Balance > 35)
            {
                Game.Instance.Player.Health += 60;
                Game.Instance.Player.Wallet.Balance -= 35;
            }
        }
        private void CoffeTime()
        {
            Game.Instance.Player.Joy += 30;
        }
        private void RestaurantTime()
        {
            if (Game.Instance.Player.Wallet.Balance > 50)
            {
                Game.Instance.Player.Wallet.Balance -= 50;
                Game.Instance.Player.Health += 35;
                Game.Instance.Player.Joy += 20;
            }
        }
        private void Police()
        {
            Game.Instance.Player.Joy += 35;
        }
        private void DeveloperMeet()
        {
            Game.Instance.Player.Joy += 30;
            
        }
        private void SeedMsg()
        {
            this.msgs.Add("developer", "Здрасти пич!\nДобре дошъл в реалноста.\nАз съм много луд Developer и ще ти кача joy с 30.");
        }
    }
}
