using UnityEngine;

[CreateAssetMenu]
public sealed class RubyResource : Resource, IStorable, ISellable, IRecyclable
{
    [SerializeField] private int cost = 6;

    [field: SerializeField] public Sprite Icon { get; private set; }
    public string Name => "Рубин";
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