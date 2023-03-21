using IceWasteland.ResourcesCore;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Script.Other
{
    public sealed class RubyOre : MonoBehaviour, IPickable
    {
        [SerializeField] GameObject rubyDustParticle;
        public event Action OnPickUp;

        private IInventory inventory;
        private RubyResource ruby;

        [Inject]
        public void Construct(IInventory inventory, ResourcesHandler resourcesHandler)
        {
            this.inventory = inventory;
            this.ruby = resourcesHandler.Get<RubyResource>() as RubyResource;
        }

        public void PickUp()
        {
            inventory.AddItem(ruby);

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public abstract class PickableResource<TResource> : MonoBehaviour, IPickable
        where TResource : Resource
    {
        public event Action OnPickUp;

        public void PickUp()
        {
            inventory.AddItem(ruby);

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}