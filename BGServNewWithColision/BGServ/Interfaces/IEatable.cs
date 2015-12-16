using BulgarianReality.Items;
using BulgarianReality.Items.Foods;

namespace BulgarianReality.Interfaces
{
    public interface IEatable
    {
        void Eat(Food food);
    }
}
