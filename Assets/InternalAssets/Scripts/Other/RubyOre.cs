using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Other
{
    public sealed class RubyOre : CollectableResource, IPickable
    {
        [SerializeField] GameObject rubyDustParticle;
        public UnityEvent OnPickUp { get; private set; } = new();

        public void PickUp()
        {
            FindObjectOfType<Inventory>().AddItem(Resource.Clone());

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}