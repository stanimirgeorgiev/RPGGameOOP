namespace BulgarianReality.Interfaces
{
    using System.Collections.Generic;

    using Humans.Workers;
    using Items;

    public interface IStealable
    {
        void Steal(Worker worker, IList<Item> items);
    }
}
