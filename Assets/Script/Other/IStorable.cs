using UnityEngine;
using UnityEngine.Events;

public interface IStorable
{
    public Sprite InventoryIcon { get; }

    public UnityEvent OnAddedToInventory { get; }
    public UnityEvent OnInInventory { get; }
    public UnityEvent OnRemovedFromInventory { get; }
}