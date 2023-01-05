using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class Inventory : MonoBehaviour
{
    private readonly List<ICollectable> items = new();
    public readonly UnityEvent<ICollectable> OnItemWasAdded = new();

    public void AddItem(ICollectable newItem)
    {
        items.Add(newItem);
        OnItemWasAdded.Invoke(newItem);
    }
    public void RemoveItems<T>(int count) where T : ICollectable
    {
        Get<T>(true, count);
    }
    public IRecyclable[] GetRecyclableItems(bool removeItems) => Get<IRecyclable>(removeItems);
    public ISellable[] GetSellableOreItems(bool removItems) => Get<ISellable>(removItems);

    private T[] Get<T>(bool removeItems, int range = int.MaxValue)
    {
        List<T> ore = new();

        for (int i = 0; i < this.items.Count; i++)
        {
            if (this.items[i] is T oreType && ore.Count < range)
            {
                if (removeItems) ore.Add(oreType);
                this.items.RemoveAt(i);
            }
        }

        return ore.ToArray();
    }
}