namespace BulgarianReality.Buildings
{
    using System.Collections.Generic;
    using System.Drawing;

    using Items;

    public class Supermarket : Building
    {
        private readonly IList<Item> items;

        public Supermarket(int id, Image image, Point location)
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
