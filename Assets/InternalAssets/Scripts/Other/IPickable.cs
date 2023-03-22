using System;

public interface IPickable
{
    event Action OnPickedUp;
    void PickUp();
}