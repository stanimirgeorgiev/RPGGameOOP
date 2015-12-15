using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drinks.AlcoholicDrinks
{
    public class Vodka : AlcoholDrink
    {
        public Vodka(string name, Human owner, decimal price, int quantity, int joyPoints) 
            : base(name, owner, price, quantity, joyPoints)
        {
        }
    }
}
