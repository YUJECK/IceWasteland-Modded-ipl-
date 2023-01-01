using UnityEngine.Events;

public interface IPickable
{
    public UnityEvent OnPickUp { get; }
    public void PickUp();
}