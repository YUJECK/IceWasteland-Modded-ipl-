using UnityEngine;
using UnityEngine.Events;

public interface ICollectable
{
    public Sprite InventoryIcon { get; }
    public string ItemName { get; }

    public UnityEvent OnAddedToInventory { get; }
    public UnityEvent OnInInventory { get; }
    public UnityEvent OnRemovedFromInventory { get; }

    public ICollectable Clone();
}