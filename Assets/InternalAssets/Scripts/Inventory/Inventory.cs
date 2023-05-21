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
    {
        OnItemWasRemoved?.Invoke(Items[typeof(TItem)][0]);
        Items.Remove(typeof(TItem));
    }

    public bool Contains<TItem>() where TItem : IStorable
        => Items.ContainsKey(typeof(TItem));

    public IRecyclable[] GetRecyclableItems(bool removeItems)
        => GetItems<IRecyclable>(removeItems);

    public ISellable[] GetSellableItems(bool removeItems) 
        => GetItems<ISellable>(removeItems);

    public IStorable[] Get<TItem>() where TItem : IStorable
        => GetItems<TItem>(false) as IStorable[];

    private TItem[] GetItems<TItem>(bool remove) 
    {
        List<TItem> ore = new();

        Debug.Log("Start");
        foreach (var item in Items)
        {
            Debug.Log("In");
            if (item.Key is TItem || item.Key.IsSubclassOf(typeof(TItem)))
            {
                Debug.Log("Is");

                if(remove)
                {
                    OnItemWasRemoved?.Invoke(Items[typeof(TItem)][0]);
                    Items.Remove(typeof(TItem));
                }
                ore.AddRange(item.Value as List<TItem>);
            }
        }

        return ore.ToArray();
    }
}