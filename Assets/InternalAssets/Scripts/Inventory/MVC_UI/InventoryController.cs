using IceWasteland.Services;
using static UnityEditor.Timeline.Actions.MenuPriority;

namespace IceWasteland.Inventory.UI
{
    public sealed class InventoryController
    {
        private readonly InventoryModel _inventoryModel;

        public InventoryController(
            IInventory inventory,
            IInputService inputService,
            InventorySlotsProvider slotsProvider)
        {
            _inventoryModel = new(inventory, inputService, slotsProvider);
            SubscribeToInputs(inputService);
            SubscribeToInventoryEvents(inventory);
        }

        private static void SubscribeToInventoryEvents(IInventory inventory)
        {
            inventory.OnItemWasAdded += AddItem;
            inventory.OnItemWasRemoved += RemoveItem;
        }

        private void SubscribeToInputs(IInputService inputService)
        {
            inputService.OnInventoryKeyDown += OnInventoryKeyDown;
            inputService.OnInventoryKeyUp += OnInventoryKeyUp;
        }


        private void OnInventoryKeyUp()
        {
            DisableInventoryUI();
        }

        private void OnInventoryKeyDown()
        {
            EnableInventoryUI();
        }

        private void DisableInventoryUI()
           => _inventoryModel.InventoryGameObject.SetActive(false);
        private void EnableInventoryUI()
            => _inventoryModel.InventoryGameObject.SetActive(true);
    }
}