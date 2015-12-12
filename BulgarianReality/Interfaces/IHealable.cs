using BulgarianReality.Humans;
using BulgarianReality.Items.Drugs;

namespace BulgarianReality.Interfaces
{
    public interface IHealable
    {
        void Heal(Human person ,Drug drug);
    }
}
