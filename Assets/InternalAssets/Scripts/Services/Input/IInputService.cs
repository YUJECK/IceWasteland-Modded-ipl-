using System;
using UnityEngine;

namespace IceWasteland.Services
{
    public interface IInputService
    {
        Vector2 GetMovement();
        event Action OnShootKeyDown;

        event Action OnInventoryKeyUp;
        event Action OnInventoryKeyDown;
    }
}