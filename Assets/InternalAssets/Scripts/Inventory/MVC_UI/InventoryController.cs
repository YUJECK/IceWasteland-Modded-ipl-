using IceWasteland.Services;
using System;
using UnityEngine;

namespace IceWasteland.Inventory.UI
{
    public sealed class InventoryController
    {
        public readonly InventoryModel InventoryModel;
        private readonly InventoryView _inventoryView;

        public event Action<IStorable> OnItemWasAdded;
        public event Action<IStorable> OnItemWasRemoved;

        public InventoryController(
            IInventory inventory, IInputService inputService, InventorySlotsProvider slotsProvider, InventoryView inventoryView, GameObject test)
        {
            InventoryModel = new(inventory, inputService, slotsProvider, test);
            this._inventoryView = inventoryView;
            
            SubscribeToInventoryEvents(inventory);
            SubscribeToInputs(inputService);
        }

        private void SubscribeToInventoryEvents(IInventory inventory)
        {
            inventory.OnItemWasAdded += OnInventoryUpdated; 
            inventory.OnItemWasRemoved += OnInventoryUpdated;
        }

        private void SubscribeToInputs(IInputService inputService)
        {
            inputService.OnInventoryKeyDown += OnInventoryKeyDown;
            inputService.OnInventoryKeyUp += OnInventoryKeyUp;
        }

        private void OnInventoryUpdated(IStorable obj)
            => _inventoryView.UpdateSlots();

        private void OnInventoryKeyUp()
            => _inventoryView.Disable();
        private void OnInventoryKeyDown()
            => _inventoryView.Enable();
    }
}