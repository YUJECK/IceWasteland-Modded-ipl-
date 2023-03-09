using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Script.Other
{
    public sealed class RubyOre : MonoBehaviour, IPickable
    {
        [SerializeField] GameObject rubyDustParticle;
        private ICollectable ruby = new RubyResource();

        public event Action OnPickUp; 

        public void PickUp()
        {
            FindObjectOfType<Inventory>().AddItem(ruby);

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}