using UnityEngine;
using UnityEngine.Events;

public sealed class SouthPickUp : MonoBehaviour, IPickable
{
    public UnityEvent OnPickUp { get; private set; }

    public void PickUp()
    {
    }
}