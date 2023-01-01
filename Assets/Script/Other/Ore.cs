using UnityEngine;
using UnityEngine.Events;

public abstract class Ore : ScriptableObject
{
    [SerializeField] private int oreCost = 0;
    [SerializeField] private bool destroyOnPickUp = true;
    [SerializeField] private Sprite oreSprite;
    [SerializeField] private Sprite oreSpriteInInventory;
    [SerializeField] private GameObject orePickUpEffect;

    public readonly UnityEvent<Ore> OnPickUp = new();

    public int OreCost => oreCost;
    public bool DestroyOnPickUp => destroyOnPickUp;
    public Sprite OreSprite => oreSprite;
    public Sprite OreSpriteInInventory => oreSpriteInInventory;
    public GameObject OrePickUpEffect => orePickUpEffect;

    public virtual void PickUp() => OnPickUp.Invoke(this);
}