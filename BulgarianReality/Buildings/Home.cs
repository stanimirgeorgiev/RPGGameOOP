namespace BulgarianReality.Buildings
{
    using System.Collections.Generic;
    using System.Drawing;

    using Items;

    public class Home : Building
    {
        private readonly IList<Item> items;
         
        public Home(int id, Image image, Point location)
            : base(id, image, location)
        {
            this.items = new List<Item>();
        }

        public IEnumerable<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Add(Item item)
        {
            this.items.Add(item);
        }
    }
}
