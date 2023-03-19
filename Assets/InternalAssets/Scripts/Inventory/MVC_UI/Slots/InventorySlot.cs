using IceWasteland.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private Text itemsCountText;

    public bool IsEmpty => ItemsStored.Count == 0;

    public Type ItemType { get; private set; }
    public List<IStorable> ItemsStored { get; private set; }

    public void AddItem(IStorable[] newItem, Type type)
    {
        if (ItemsStored == null)
        {
            Debug.LogError("You tried to add null item");
            return;
        }

        ItemsStored.AddRange(newItem);
    }
    public void RemoveItem()
    {
        ItemsStored.RemoveAt(ItemsStored.Count);
        DisableSlot();
    }

    private void DisableSlot()
    {
        itemIcon.gameObject.SetActive(false);
        itemsCountText.gameObject.SetActive(false);
    }
    public override string ToString() => ItemsStored[0].Config.Name;
}