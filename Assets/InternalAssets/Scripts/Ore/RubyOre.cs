using System;
using UnityEngine;

namespace Assets.Script.Other
{
    public sealed class RubyOre : MonoBehaviour, IPickable
    {
        [SerializeField] GameObject rubyDustParticle;
        private IStorable ruby = new RubyResource();

        public event Action OnPickUp;

        public void PickUp()
        {
            FindObjectOfType<Inventory>().AddItem(ruby); 

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}