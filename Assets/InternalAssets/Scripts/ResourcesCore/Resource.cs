using IceWasteland.Inventory;
using UnityEngine;

namespace IceWasteland.ResourcesCore
{
    public abstract class Resource : ScriptableObject, IStorable
    {
        [field: SerializeField] public StorableConfig Config { get; private set; }

        public virtual void OnAdded() { }
        public virtual void OnInInventory() { }
        public virtual void OnRemoved() { }
    }
} 