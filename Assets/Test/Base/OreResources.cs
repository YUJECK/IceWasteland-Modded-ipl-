using UnityEngine;

namespace RimuruDev.DotNetDesignPattern.SOLID.OCP
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public class OreResources<TResource> : ResourcesBase
        where TResource : MonoBehaviour
    {
        private TResource oreImplementation;
        private Collider oreCollider;

        private void Awake()
        {
            oreImplementation = GetComponent<TResource>();
            oreCollider = GetComponent<Collider>();
        }
    }
}