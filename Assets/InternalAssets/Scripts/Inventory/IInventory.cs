using System;

public interface IInventory
{
    event Action<ICollectable> OnItemWasAdded;
    event Action<ICollectable> OnItemWasRemoved;

    void AddItem(ICollectable newItem);
    IRecyclable[] GetRecyclableItems(bool removeItems);
    ISellable[] GetSellableItems(bool removItems);
    void RemoveItems<T>(int count = int.MaxValue) where T : ICollectable;
}