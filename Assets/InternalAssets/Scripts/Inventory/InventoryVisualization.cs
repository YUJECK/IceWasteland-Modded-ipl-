using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryVisualization : MonoBehaviour
{
    [SerializeField] private GameObject inventoryGameObject;
    [SerializeField] private IInventory inventory;
    [SerializeField] private List<InventorySlot> slots = new();
    private int lastNotOccupiedSlot = 0;

    [Inject]
    public void Construct(IInventory inventory)
        => this.inventory = inventory;

    private void Start()
    {
        inventory.OnItemWasAdded += AddItem;
        inventory.OnItemWasRemoved += RemoveItem;
    }
    private void OnDestroy()
    {
        inventory.OnItemWasAdded -= AddItem;
        inventory.OnItemWasRemoved -= RemoveItem;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) inventoryGameObject.SetActive(true);
        if (Input.GetKeyUp(KeyCode.E)) inventoryGameObject.SetActive(false);
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

        ComposeItems();
    }
    private void RemoveItem(ICollectable removeItem)
    {
        FindSlotWithTypeFromItem(removeItem)?.RemoveCurrentItem();
        ComposeItems();
    }
    private void ComposeItems()
    {
        bool hasEmptySlot = false;

        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].CurrentItem == null)
                hasEmptySlot = true;

            else if (hasEmptySlot)
            {
                slots[i - 1].AddItem(slots[i].CurrentItem);
                slots[i].RemoveCurrentItem();
            }
        }
    }


    private InventorySlot FindSlotWithTypeFromItem(ICollectable item)
    {
        if (item != null)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].CurrentItem == null)
                    break;
                if (slots[i].CurrentItem.GetType() == item.GetType())
                    return slots[i];
            }
        }
        else throw new NullReferenceException(nameof(item));

        return null;
    }
}