using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
class RubyResource : Resource, ICollectable, ISellable, IRecyclable
{
    [SerializeField] private int cost = 6;
    [SerializeField] private Sprite inventoryIcon;

    public UnityEvent OnAddedToInventory { get; private set; }
    public UnityEvent OnInInventory { get; private set; }
    public UnityEvent OnRemovedFromInventory { get; private set; }
    public UnityEvent OnSale { get; private set; }

    public Sprite InventoryIcon => inventoryIcon;
    public string ItemName => "Рубин";
    public int Cost => cost;


    public ICollectable Clone() => Instantiate(this);

    public void Recycle()
    {
        Debug.Log("Ruby has been recycled");

        //adding to inventory pure version of ruby

        Destroy(this);
    }
}