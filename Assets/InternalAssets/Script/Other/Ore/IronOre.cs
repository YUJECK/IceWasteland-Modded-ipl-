using UnityEngine;
using UnityEngine.Events;

public class IronOre : CollectableResource, IPickable
{
    [SerializeField] GameObject ironDustParticle;
    public UnityEvent OnPickUp { get; private set; }

    public void PickUp()
    {
        FindObjectOfType<Inventory>().AddItem(Resource.Clone());
        Instantiate(ironDustParticle, transform.position, transform.rotation);
        Destroy(gameObject); 
    }
}