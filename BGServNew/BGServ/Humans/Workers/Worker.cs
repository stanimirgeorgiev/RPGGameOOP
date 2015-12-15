using BulgarianReality.Interfaces;
using BulgarianReality.Items.Belongings;

namespace BulgarianReality.Humans.Workers
{
    using System.Drawing;

    using BulgarianReality.Enums;

    public abstract class Worker : Human, IWorkable

    {

        protected Worker(int id, string firstname, string lastname, int age, Gender gender,int health, int joy, 
            Wallet wallet, Point location, Image image)
            : base(id, firstname, lastname, age, gender, health, joy, wallet, location, image)
        {
        }

        public abstract void Work();
    }
}
