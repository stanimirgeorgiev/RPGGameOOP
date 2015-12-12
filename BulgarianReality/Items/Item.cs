using System;
using BulgarianReality.Humans;

namespace BulgarianReality.Items
{
    public abstract class Item
    {
        private string name;
        private decimal price;
        private int quantity;
        private Human owner;

        protected Item(string name, Human owner, decimal price, int quantity)
        {
            this.Name = name;
            this.Owner = owner;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null, empty or whitespace.");
                }
            }
        }

        public Human Owner { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
