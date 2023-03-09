using System;
using UnityEngine;

public interface ICollectable
{
    Sprite InventoryIcon { get; }
    string ItemName { get; }

    void OnAdded();
    void OnRemoved();
    void OnInInventory();
}