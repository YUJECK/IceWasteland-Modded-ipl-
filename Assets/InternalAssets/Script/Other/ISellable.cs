using UnityEngine.Events;

public interface ISellable
{
    int Cost { get; }
    UnityEvent OnSold { get; }
}