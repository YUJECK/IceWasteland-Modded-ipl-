using System;
using UnityEngine;

namespace IceWasteland.Services
{
    public interface IInputService
    {
        Vector2 GetMovement();
        bool IsShootKeyDown();

        event Action OnInventoryKeyUp;
        event Action OnInventoryKeyDown;
    }
}