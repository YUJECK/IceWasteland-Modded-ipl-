using IceWasteland.Services;
using UnityEngine;

public sealed class InputService : IInputService
{
    private Vector2 movement;
    
    public Vector2 GetMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        return movement;
    }

    public bool IsInventoryKeyDown()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    public bool IsInventoryKeyUp()
    {
        return Input.GetKeyUp(KeyCode.E);
    }

    public bool IsShootKeyDown()
    {
        return Input.GetMouseButtonDown(0);
    }
}