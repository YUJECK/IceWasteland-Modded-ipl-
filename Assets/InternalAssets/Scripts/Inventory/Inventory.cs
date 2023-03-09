using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory : MonoBehaviour, IInventory
{
    private readonly List<ICollectable> items = new();

    public event Action<ICollectable> OnItemWasAdded;
    public event Action<ICollectable> OnItemWasRemoved;

    private void Update()
    {
        for (int i = 0; i < items.Count; i++)
            items[i].OnInInventory();
    }

    public void AddItem(ICollectable newItem)
    {
        items.Add(newItem);
        OnItemWasAdded.Invoke(newItem);
    }
    public void RemoveItems<T>(int count = int.MaxValue) where T : ICollectable
    {
        GetItems<T>(count, true);
    }
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
                    OnItemWasRemoved?.Invoke(nextOre as ICollectable);
                }
            }
        }

        return ore.ToArray();
    }
}