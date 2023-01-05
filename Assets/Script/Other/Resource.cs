using UnityEngine;

public abstract class Resource : ScriptableObject
{
    [SerializeField] private Sprite oreSprite;
    [SerializeField] private string oreName;

    public Sprite OreSprite => oreSprite;
    public string OreName => oreName;
}