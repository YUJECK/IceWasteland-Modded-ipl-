using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu()]
public sealed class IronResource : Resource, ICollectable, ISellable, IRecyclable
{
    [SerializeField] private int cost = 6;
        
    public UnityEvent OnAddedToInventory { get; private set; }
    public UnityEvent OnInInventory { get; private set; }
    public UnityEvent OnRemovedFromInventory { get; private set; }
    public UnityEvent OnSold { get; private set; }

    [field: SerializeField] public Sprite InventoryIcon { get; private set; }
    public string ItemName => "Железо";
    public int Cost => cost;


    public ICollectable Clone() => Instantiate(this);

    public void Recycle()
    {
        Debug.Log("iron has been recycled");

        Destroy(this);
    }
}