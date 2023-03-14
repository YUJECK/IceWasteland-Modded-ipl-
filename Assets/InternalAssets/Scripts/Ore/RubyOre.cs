using IceWasteland.ResourcesCore;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Script.Other
{
    public sealed class RubyOre : MonoBehaviour, IPickable
    {
        [SerializeField] GameObject rubyDustParticle;
        private IInventory inventory;

        public event Action OnPickUp;

        private RubyResource ruby;

        [Inject]
        public void Construct(IInventory inventory, ResourcesHandler resourcesHandler)
        {
            this.inventory = inventory;
            this.ruby = (resourcesHandler.Get<RubyResource>() as RubyResource);
        }
        
        public void PickUp()
        {
            inventory.AddItem(ruby);

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}