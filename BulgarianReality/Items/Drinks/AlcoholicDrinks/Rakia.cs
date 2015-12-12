using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drinks.AlcoholicDrinks
{
    public class Rakia : AlcoholDrink
    {
        public Rakia(string name, Human owner, decimal price, int quantity, int joyPoints) 
            : base(name, owner, price, quantity, joyPoints)
        {
        }
    }
}
