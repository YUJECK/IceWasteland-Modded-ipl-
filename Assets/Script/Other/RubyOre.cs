using UnityEngine.Events;

namespace Assets.Script.Other
{
    public sealed class RubyOre : CollectableResource, IPickable
    {
        public UnityEvent OnPickUp { get; private set; } = new();

        public void PickUp()
        {
            FindObjectOfType<Inventory>().AddItem(Resource.Clone());
        }
    }
}