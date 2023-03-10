namespace RimuruDev.DotNetDesignPattern.SOLID.OCP
{
    public interface IInteractable
    {
        public void Interact();
    }

    public interface IPickable : IDroppable
    {
        public void Pickup();
    }

    public interface IDroppable
    {
        public void Drop();
    }
}