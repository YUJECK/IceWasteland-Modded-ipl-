using IceWasteland.ResourcesCore;

namespace IceWasteland.Inventory
{
    public interface IStorable
    {
        public StorableConfig Config { get; }

        void OnAdded();
        void OnRemoved();
        void OnInInventory();
    }
}