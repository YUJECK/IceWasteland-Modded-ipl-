using UnityEngine;

namespace IceWasteland.ResourcesCore
{
    public abstract class SellableResource : Resource, ISellable
    {
        [field: SerializeField] public int Cost { get; protected set; }

        public virtual void OnSold() { }
    }
}