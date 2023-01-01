using UnityEngine;
using UnityEngine.Events;

public class OrePickUp : MonoBehaviour
{
    [SerializeField] private Ore ore;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public readonly UnityEvent OnOreInited = new();

    private void Awake()
    {
        InitOre();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ore != null)
        {
            Debug.Log("enter");

            ore.PickUp();
        
            if(ore.OrePickUpEffect != null)
                Instantiate(ore.OrePickUpEffect, transform.position, transform.rotation);
        }
    }

    private void InitOre()
    {
        if (ore != null)
        {
            if (spriteRenderer == null)
            {
                GameObject newSpriteRenderer = Instantiate(new GameObject(), transform);
                spriteRenderer = newSpriteRenderer.AddComponent<SpriteRenderer>();
            }

            spriteRenderer.sprite = ore.OreSprite;

            OnOreInited.Invoke();
        }
        else Destroy(gameObject);
    }
    public void SetOre(Ore newOre)
    {
        ore = newOre;
        InitOre();
    }
}