using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu()]
public sealed class Iron : ScriptableObject, IStorable, ISellable, IRecyclable
{
    [SerializeField] private int cost = 6;
    [SerializeField] private Sprite inventoryIcon;
        
    public UnityEvent OnAddedToInventory { get; private set; }
    public UnityEvent OnInInventory { get; private set; }
    public UnityEvent OnRemovedFromInventory { get; private set; }
    public UnityEvent OnSale { get; private set; }

    public Sprite InventoryIcon => inventoryIcon;
    public int Cost => cost;

    public void Recycle()
    {
        throw new System.NotImplementedException();
    }
}