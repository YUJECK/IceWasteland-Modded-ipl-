namespace IceWasteland.ResourcesCore
{
    public abstract class SellableRecyclableResource : SellableResource, IRecyclable
    {
        public abstract void Recycle();
    }
}