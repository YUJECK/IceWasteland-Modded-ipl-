using UnityEngine;

namespace IceWasteland.Services
{
    public interface IInputService
    {
        Vector2 GetMovement();
        bool IsShootKeyDown();
        bool IsInventoryKeyUp();
        bool IsInventoryKeyDown();
    }
}