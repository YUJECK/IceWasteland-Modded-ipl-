namespace IceWasteland.ResourcesCore
{
    public abstract class SellableRecyclableResource : SellableResource, IRecyclable
    {
        public virtual void Recycle() { }
    }
}