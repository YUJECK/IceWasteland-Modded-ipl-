using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualization : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private List<InventorySlot> slots = new();
    private int lastNotOccupiedSlot = 0;

    private void OnEnable()
    {
        FindObjectOfType<Inventory>().OnItemWasAdded += AddItem;
        FindObjectOfType<Inventory>().OnItemWasRemoved += RemoveItem;
    }
    private void OnDisable()
    {
        FindObjectOfType<Inventory>().OnItemWasAdded -= AddItem;
        FindObjectOfType<Inventory>().OnItemWasRemoved -= RemoveItem;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) inventory.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E)) inventory.SetActive(false);
    }

    private void AddItem(ICollectable newItem)
    {
        InventorySlot slot = FindSlotWithTypeFromItem(newItem);

        if (slot == null)
        {
            slots[lastNotOccupiedSlot].AddItem(newItem);
            lastNotOccupiedSlot++;
        }
        else slot.AddItem(newItem);
    }
    private void RemoveItem(ICollectable removeItem)
    {
        FindSlotWithTypeFromItem(removeItem)?.RemoveCurrentItem();

        //lastNotOccupiedSlot++;
    }

    private InventorySlot FindSlotWithTypeFromItem(ICollectable item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CurrentItem == null)
                break;
            if (slots[i].CurrentItem.GetType() == item.GetType())
                return slots[i];
        }
        return null;
    }
}