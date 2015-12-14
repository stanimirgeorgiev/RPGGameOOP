﻿using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Vegetables
{
    public abstract class Vegetable : Food
    {
        protected Vegetable(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}