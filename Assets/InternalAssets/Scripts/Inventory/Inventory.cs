using IceWasteland.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class Inventory : MonoBehaviour, IInventory, ITickable
{
    private readonly List<IStorable> items = new();

    public event Action<IStorable> OnItemWasAdded;
    public event Action<IStorable> OnItemWasRemoved;

    public void Tick()
    {
        foreach(var item in items)
            item.OnInInventory();
    }
        
    public void AddItem(IStorable newItem)
    {
        items.Add(newItem);
        OnItemWasAdded.Invoke(newItem);
    }
    public void RemoveItems<T>(int count = int.MaxValue) where T : IStorable
        => GetItems<T>(count, true);

    public IRecyclable[] GetRecyclableItems(bool removeItems) => GetItems<IRecyclable>(int.MaxValue, removeItems);
    
    public ISellable[] GetSellableItems(bool removItems) => GetItems<ISellable>(int.MaxValue, removItems);

    private T[] GetItems<T>(int range = int.MaxValue, bool remove = false)
    {
        List<T> ore = new();

        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i] is T nextOre && ore.Count < range)
            {
                ore.Add(nextOre);

                if (remove)
                {
                    this.items.RemoveAt(i);
                    OnItemWasRemoved?.Invoke(nextOre as IStorable);
                }
            }
        }

        return ore.ToArray();
    }

}