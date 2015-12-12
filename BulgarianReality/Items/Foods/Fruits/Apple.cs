﻿using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Fruits
{
    public class Apple : Fruit
    {
        public Apple(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
