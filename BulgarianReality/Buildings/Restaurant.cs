namespace BulgarianReality.Buildings
{
    using System.Collections.Generic;
    using System.Drawing;

    using Items;

    public class Restaurant : Building
    {
        private readonly IList<Item> items;
         
        public Restaurant(int id, Image image, Point location)
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

        public void Remove(Item item)
        {
            this.items.Remove(item);
        }
    }
}
