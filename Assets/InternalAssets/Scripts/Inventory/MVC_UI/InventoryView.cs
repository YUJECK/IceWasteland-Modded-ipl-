﻿using IceWasteland.Infrastructure;
using IceWasteland.Services;
using UnityEngine;
using Zenject;

namespace IceWasteland.Inventory.UI
{
    public sealed class InventoryView : MonoBehaviour, ISwitchable
    {
        private InventoryController _inventoryController;
        private readonly InventorySlotsProvider _slotsProvider;

        public bool IsEnabled { get; private set; }

        [Inject]
        public void Construct(IInventory inventory, IInputService inputService, InventorySlotsProvider slotsProvider)
            => _inventoryController = new(inventory, inputService, slotsProvider, this, transform.GetChild(0).gameObject);

        public void UpdateSlots()
        {
            int slot = 0;

            foreach (var item in _inventoryController.InventoryModel.Inventory.Items)
            {
                _inventoryController.InventoryModel.Slots[slot].AddItem(item.Value.ToArray(), item.Key);
                slot++;
            }
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}