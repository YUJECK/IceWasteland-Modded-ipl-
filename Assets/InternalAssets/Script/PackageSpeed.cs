using UnityEngine;
using UnityEngine.Events;

public class PackageSpeed : MonoBehaviour, IPickable
{
    public UnityEvent OnPickUp { get; private set; }

    public void PickUp()
    {
        FindObjectOfType<PlayerMovable>().MoveSpeed += 2;
    }
}