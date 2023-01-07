using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class Inventory : MonoBehaviour
{
    private readonly List<ICollectable> items = new();

    public readonly UnityEvent<ICollectable> OnItemWasAdded = new();
    public readonly UnityEvent<ICollectable> OnItemWasRemoved = new();

    private void Update()
    {
        for (int i = 0; i < items.Count; i++)
            items[i].OnInInventory.Invoke();
    }

    public void AddItem(ICollectable newItem)
    {
        items.Add(newItem);
        OnItemWasAdded.Invoke(newItem);
    }
    public void RemoveItems<T>(int count = int.MaxValue) where T : ICollectable => GetItems<T>(count, true);
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
                    OnItemWasRemoved.Invoke(this.items[i]);
                }
            }
        }

        return ore.ToArray();
    }
}