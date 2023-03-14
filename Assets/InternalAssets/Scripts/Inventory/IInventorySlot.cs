using IceWasteland.Inventory;

public interface IInventorySlot
{
    IStorable CurrentItem { get; }

    void AddItem(IStorable newItem);
    void RemoveCurrentItem();
}