using System;

public interface IPickable
{
    event Action OnPickUp;
    void PickUp();
}