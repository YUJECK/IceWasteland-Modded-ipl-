using IceWasteland.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public sealed class Inventory : MonoBehaviour, IInventory, ITickable
{
    public Dictionary<Type, List<IStorable>> Items { get; } = new();

    public event Action<IStorable> OnItemWasAdded;
    public event Action<IStorable> OnItemWasRemoved;

    public void Tick()
    {
        foreach(KeyValuePair<Type, List<IStorable>> itemList in Items)
        {
            foreach (IStorable item in itemList.Value)
                item.OnInInventory();
        }
    }
        
    public void AddItem<TItem>(TItem newItem) where TItem : IStorable
    {
        Items.TryAdd(
            typeof(TItem),
            new List<IStorable>());

        Items[typeof(TItem)].Add(newItem);

        OnItemWasAdded?.Invoke(newItem);
    }
    public void RemoveItems<TItem>() where TItem : IStorable
        => Items.Remove(typeof(TItem));

    public bool Contains<TItem>() where TItem : IStorable
        => Items.ContainsKey(typeof(TItem));


    public IRecyclable[] GetRecyclableItems(bool removeItems)
        => GetItems<IRecyclable>(removeItems);

    public ISellable[] GetSellableItems(bool removeItems) 
        => GetItems<ISellable>(removeItems);

    private T[] GetItems<T>(bool remove)
    {
        List<T> ore = new();

        foreach (var item in Items)
        {
            if (item.Key is T)
            {
                if(remove) Items.Remove(item.Key);
                ore.AddRange(item.Value as List<T>);
            }
        }

        return ore.ToArray();
    }

    public IStorable[] Get<TItem>() where TItem : IStorable
    {
        return GetItems<TItem>(false) as IStorable[];
    }
}