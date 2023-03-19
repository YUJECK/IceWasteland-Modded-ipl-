using IceWasteland.Inventory;
using System;
using System.Collections.Generic;

public interface IInventory
{
    Dictionary<Type, List<IStorable>> Items { get; }

    event Action<IStorable> OnItemWasAdded;
    event Action<IStorable> OnItemWasRemoved;

    void AddItem<TItem>(TItem newItem) where TItem : IStorable;
    void RemoveItems<T>() where T : IStorable;

    bool Contains<TItem>() where TItem : IStorable;
    IStorable[] Get<TItem>() where TItem : IStorable;
    IRecyclable[] GetRecyclableItems(bool removeItems);
    ISellable[] GetSellableItems(bool removeItems);
}