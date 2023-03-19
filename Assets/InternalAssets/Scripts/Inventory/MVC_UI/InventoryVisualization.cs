//using IceWasteland.Inventory;
//using IceWasteland.Services;
//using System;
//using System.Collections.Generic;
//using UnityEngine;
//using Zenject;

//public class InventoryVisualization : MonoBehaviour
//{
//    [SerializeField] private GameObject inventoryGameObject;
//    private List<InventorySlot> slots = new();
//    private int lastNotOccupiedSlot = 0;

//    private IInventory inventory;
//    private IInputService inputService;

//    [Inject]
//    public void Construct(IInventory inventory, IInputService inputService, InventorySlotsProvider slotsProvider)
//    {
//        this.inventory = inventory;
//        this.inputService = inputService;
//        this.slots = slotsProvider.Get();
//    }

//    private void Start()
//    {
//        inventory.OnItemWasAdded += AddItem;
//        inventory.OnItemWasRemoved += RemoveItem;
//    }
//    private void OnDestroy()
//    {
//        inventory.OnItemWasAdded -= AddItem;
//        inventory.OnItemWasRemoved -= RemoveItem;
//    }
//    private void Update()
//    {
//        if (inputService.OnInventoryKeyDown())
//            EnableInventoryUI();

//        if (inputService.OnInventoryKeyUp())
//            DisableInventoryUI();
//    }

//    private void DisableInventoryUI()
//        => inventoryGameObject.SetActive(false);
//    private void EnableInventoryUI()
//        => inventoryGameObject.SetActive(true);

//    private void AddItem(IStorable newItem)
//    {
//        InventorySlot slot = FindSlotWithTypeFromItem(newItem);

//        if (slot == null)
//        {
//            slots[lastNotOccupiedSlot].AddItem(newItem);
//            lastNotOccupiedSlot++;
//        }
//        else slot.AddItem<>(newItem);

//        ComposeItems();
//    }
//    private void RemoveItem(IStorable removeItem)
//    {
//        FindSlotWithTypeFromItem(removeItem)?.RemoveItem();
//        ComposeItems();
//    }
//    private void ComposeItems()
//    {
//        Stack<InventorySlot> emptySlots = new();

//        for (int i = 0; i < slots.Count; i++)
//        {
//            if (slots[i].IsEmpty)
//                emptySlots.Push(slots[i]);

//            else if (emptySlots.Count > 0)
//            {
//                emptySlots.Peek().AddItem(slots[i].ItemsStored);
//                slots[i].RemoveItem();
//            }
//        }
//    }


//    private InventorySlot FindSlotWithTypeFromItem(IStorable item)
//    {
//        if (item != null)
//        {
//            for (int i = 0; i < slots.Count; i++)
//            {
//                if (slots[i].IsEmpty) break;

//                if (CompareTypes(slots[i].ItemType, item.GetType()))
//                    return slots[i];
//            }
//        }
//        else throw new NullReferenceException(nameof(item));

//        return null;
//    }

//    private bool CompareTypes(Type type1, Type type2)
//        => type1 == type2;
//}