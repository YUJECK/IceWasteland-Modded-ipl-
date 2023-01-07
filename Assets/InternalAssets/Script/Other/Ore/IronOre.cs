using UnityEngine.Events;

public class IronOre : CollectableResource, IPickable
{
    public UnityEvent OnPickUp { get; private set; }

    public void PickUp()
    {
        FindObjectOfType<Inventory>().AddItem(Resource.Clone());
        Destroy(gameObject); 
    }
}