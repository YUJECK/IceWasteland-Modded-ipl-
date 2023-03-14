using IceWasteland.Services;
using UnityEngine;
using Zenject;

namespace IceWasteland.Inventory.UI
{
    public sealed class InventoryView : MonoBehaviour
    {
        private InventoryController _inventoryController;

        [Inject]
        public void Construct(IInventory inventory, IInputService inputService, InventorySlotsProvider slotsProvider)
            => _inventoryController = new(inventory, inputService, slotsProvider);
    }
}