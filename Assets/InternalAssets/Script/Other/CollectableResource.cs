using AutumnForest.Editor;
using UnityEngine;

public abstract class CollectableResource : MonoBehaviour
{
    [SerializeField, Interface(typeof(ICollectable))] protected Resource resource;
    public ICollectable Resource => resource as ICollectable;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (spriteRenderer != null) spriteRenderer.sprite = resource.OreSprite;
        else Debug.LogError("Sprite renderer is null");
    }
}