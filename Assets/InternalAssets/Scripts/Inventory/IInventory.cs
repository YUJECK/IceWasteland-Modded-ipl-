using IceWasteland.Inventory;
using System;

public interface IInventory
{
    event Action<IStorable> OnItemWasAdded;
    event Action<IStorable> OnItemWasRemoved;

    void AddItem(IStorable newItem);
    IRecyclable[] GetRecyclableItems(bool removeItems);
    ISellable[] GetSellableItems(bool removItems);
    void RemoveItems<T>(int count = int.MaxValue) where T : IStorable;
}