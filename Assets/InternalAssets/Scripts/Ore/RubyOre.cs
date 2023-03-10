using System;
using UnityEngine;

namespace Assets.Script.Other
{
    public sealed class RubyOre : MonoBehaviour, IPickable
    {
        [SerializeField] GameObject rubyDustParticle;

        public event Action OnPickUp;

        public void PickUp()
        {

            Instantiate(rubyDustParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}