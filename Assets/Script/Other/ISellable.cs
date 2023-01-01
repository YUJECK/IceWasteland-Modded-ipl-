using UnityEngine.Events;

public interface ISellable
{
    public int Cost { get; }
    public UnityEvent OnSale { get; }
}