using IceWasteland.ResourcesCore;
using UnityEngine;

namespace IceWasteland
{
    [CreateAssetMenu()]
    public class MetalResource : SellableRecyclableResource
    {
        public override void Recycle()
        {
            Debug.Log("asdas");
        }

    }
}