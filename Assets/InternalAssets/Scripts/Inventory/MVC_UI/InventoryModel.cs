using IceWasteland.Services;
using System.Collections.Generic;
using UnityEngine;

namespace IceWasteland.Inventory.UI
{
    public sealed class InventoryModel
    {
        public GameObject InventoryGameObject { get; private set; }
        public readonly List<InventorySlot> Slots;
        public int lastNotOccupiedSlot = 0;

        public readonly IInventory Inventory;
        public readonly IInputService InputService;

        public InventoryModel(IInventory inventory, IInputService inputService, InventorySlotsProvider slotsProvider, GameObject ui)
        {
            Inventory = inventory;
            InputService = inputService;
            Slots = slotsProvider.Get();

            InventoryGameObject = ui;
        }
    }
}