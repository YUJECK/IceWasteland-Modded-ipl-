using IceWasteland.ResourcesCore;
using UnityEngine;

[CreateAssetMenu()]
public sealed class RubyResource : SellableRecyclableResource
{
    public override void Recycle()
    {
        Debug.Log("Recycle");
    }
}