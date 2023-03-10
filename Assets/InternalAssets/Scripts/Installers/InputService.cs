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
        => Input.GetKeyDown(KeyCode.E);

    public bool IsInventoryKeyUp()
        => Input.GetKeyUp(KeyCode.E);

    public bool IsShootKeyDown()
        => Input.GetMouseButtonDown(0);
}