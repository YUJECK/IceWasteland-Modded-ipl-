using UnityEngine;
using UnityEngine.UI;

public sealed class InventorySlot : MonoBehaviour
{
    public ICollectable CurrentItem { get; private set; }
    private int itemsCount = 0; 
    [SerializeField] private Image itemIcon;
    [SerializeField] private Text itemsCountText;

    public void AddItem(ICollectable newItem)
    {
        if (CurrentItem == null)
            InitItem(newItem);
        else
        {
            itemsCount++;
            itemsCountText.text = itemsCount.ToString();
        }
    }
    public void RemoveCurrentItem()
    {
        CurrentItem = null;

        itemsCount = 0;
        itemIcon.gameObject.SetActive(false);
        itemsCountText.gameObject.SetActive(false);
    }

    private void InitItem(ICollectable newItem)
    {
        if (CurrentItem == null)
        {
            CurrentItem = newItem;
            itemIcon.sprite = newItem.InventoryIcon;
            itemsCount = 1;
        }
        else
            Debug.LogError($"Cant add new item {newItem.ItemName}. Slot is alreadt occupied");
    }

    public override string ToString() => CurrentItem.ItemName;
}