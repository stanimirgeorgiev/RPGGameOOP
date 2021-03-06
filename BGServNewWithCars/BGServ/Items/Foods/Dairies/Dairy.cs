﻿using BulgarianReality.Humans;

namespace BulgarianReality.Items.Foods.Dairies
{
    public abstract class Dairy : Food
    {
        protected Dairy(string name, Human owner, decimal price, int quantity, int healthPoints) 
            : base(name, owner, price, quantity, healthPoints)
        {
        }
    }
}
