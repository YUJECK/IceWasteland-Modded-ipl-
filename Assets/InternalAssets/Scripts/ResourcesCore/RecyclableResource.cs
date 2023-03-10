namespace IceWasteland.ResourcesCore
{
    public abstract class RecyclableResource : Resource, IRecyclable
    {
        public abstract void Recycle();
    }
}