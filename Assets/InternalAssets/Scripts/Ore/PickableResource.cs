using System;
using UnityEngine;
using Zenject;

namespace IceWasteland.ResourcesCore
{
    public abstract class PickableResource<TResource> : MonoBehaviour, IPickable
        where TResource : Resource
    {
        [SerializeField] GameObject pickupEffect;

        public event Action OnPickedUp;

        private IInventory inventory;
        private TResource resource;

        [Inject]
        public void Construct(IInventory inventory, ResourcesHandler resourcesHandler)
        {
            this.inventory = inventory;
            this.resource = resourcesHandler.Get<TResource>() as TResource;
        }

        public void PickUp()
        {
            inventory.AddItem(resource);

            DestroyGameObject();
        }

        private void DestroyGameObject()
        {
            //TODO: мб добавить пулы 
            Instantiate(pickupEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        protected virtual void OnPickUp() { }
    }
}