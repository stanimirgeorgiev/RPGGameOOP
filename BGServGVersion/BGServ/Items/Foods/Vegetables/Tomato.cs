using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Vegetables
{
    public class Tomato : Vegetable
    {
        public Tomato(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
