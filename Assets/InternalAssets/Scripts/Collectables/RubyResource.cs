using UnityEngine;

[CreateAssetMenu]
public sealed class RubyResource : Resource, ICollectable, ISellable, IRecyclable
{
    [SerializeField] private int cost = 6;

    [field: SerializeField] public Sprite InventoryIcon { get; private set; }
    public string ItemName => "Рубин";
    public int Cost => cost;

    public void OnAdded() { }
    public void OnInInventory() { }
    public void OnRemoved() { }

    public void OnSold() { }

    public void Recycle()
    {
        FindObjectOfType<Inventory>().RemoveItems<RubyResource>(1);
    }
}