using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class SouthPickUp : MonoBehaviour, IPickable
{
    public UnityEvent OnPickUp { get; private set; }

    event Action IPickable.OnPickUp
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    public void PickUp()
    {
    }
}