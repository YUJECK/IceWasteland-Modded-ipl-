using System.Collections.Generic;
using UnityEngine;

public class InventoryVisualization : MonoBehaviour
{
    private List<InventorySlot> slots = new();
    private int lastNotOccupiedSlot = 0;

    private void OnEnable()
    {
        FindObjectOfType<Inventory>().OnItemWasAdded.AddListener(AddItem);
    }
    private void OnDisable()
    {
        FindObjectOfType<Inventory>().OnItemWasAdded.RemoveListener(AddItem);
    }

    private void AddItem(ICollectable newItem)
    {
        slots[lastNotOccupiedSlot].AddItem(newItem);

        lastNotOccupiedSlot++;
    }
    private void RemoveItem(ICollectable removeItem)
    {
        FindSlotWithItem(removeItem)?.RemoveCurrentItem();

        //lastNotOccupiedSlot++;
    }

    private InventorySlot FindSlotWithItem(ICollectable item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i] == null) break;
            if (slots[i].CurrentItem == item) return slots[i];
        }
        return null;
    }
}