using BulgarianReality.Humans;

namespace BulgarianReality.Items.Drinks.AlcoholicDrinks
{
    public abstract class AlcoholDrink : Drink
    {
        protected AlcoholDrink(string name, Human owner, decimal price, int quantity, int joyPoints) 
            : base(name, owner, price, quantity, joyPoints)
        {
        }
    }
}
