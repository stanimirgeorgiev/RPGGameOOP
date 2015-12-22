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
                case "Policeman": this.PoliceMeet();
                    break;
                case "Doctor": this.DoctorMeet();
                    break;
                case "Mayor": this.MayorMeet();
                    break;
                case "Rapist": this.RapistMeet();
                    break;
                case "MassMurderer": this.MassmurdererMeet();
                    break;
                case "Thief": this.ThiefMeet();
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
        private void PoliceMeet()
        {

        }
        private void DoctorMeet()
        {
            Game.Instance.Player.Health += 25;
        }
        private void MayorMeet()
        {
            Game.Instance.Player.Health -= 15;
        }
        private void RapistMeet()
        {
            Game.Instance.Player.Health -= 40;
            Game.Instance.Player.Joy = -40;
        }
        private void MassmurdererMeet()
        {
            Game.Instance.Player.Health -= Game.Instance.Player.Health/2;
        }
        private void ThiefMeet()
        {
            Game.Instance.Player.Wallet.Balance = 0;
        }
        private void SeedMsg()
        {
            //doctor, developer, mayor, policeman, rapist, massmurderer, thief
            this.msgs.Add("developer", "Здрасти пич!\nДобре дошъл в реалноста.\nАз съм много луд Developer и ще ти кача joy с 30.");
            this.msgs.Add("policeman", "Бъде сигурен!\nВсичко е под контрол!");
            this.msgs.Add("doctor", "Привет, аз съм колега на доктор Енчев и\n ще ти вдигна здравето с 25.");
            this.msgs.Add("mayor", "Tоку що се сблъска с подкупния кмет.\nНеприятна среща губиш 15 кръв.");
            this.msgs.Add("rapist", "Най-после ми падна в лапите, перверзно човече,\nЕла да се позабавляваме!\n -40 кръв, -40 Joy!");
            this.msgs.Add("massmurderer", "Горе ръцете!!!\nСтрелям и ти взимам половината кръв!");
            this.msgs.Add("thief", "Oбран си пич. Аз съм най-опасният крадец в София!\nСбогувй се с парите си!!!");
            //BuildingMessages
            this.msgs.Add("coffee", "Добре дошъл в Starbucks!\nKeep calm and relax! Joy +30");
            this.msgs.Add("supermarlet", "Metro cash & carry на вашите услуги!\n Health +60, Money -35");
            this.msgs.Add("hospital", "Ти си в Токуда.\nНие ще се погрижим за здравето ти.Health +25");
            this.msgs.Add("office", "Работи и печели.\nMoney +80");
            this.msgs.Add("policestation", "РПУ София на Вашите услуги!\nJoy +35");
            this.msgs.Add("bank", "Нуждаеш се от пари?\nУникредит ще ти даде безвъзмезден кредит!\nMoney +10");
            this.msgs.Add("restaurant", "Be happy in Happy.\nMoney -50, Health +35, Joy +20");



            
        }
    }
}
