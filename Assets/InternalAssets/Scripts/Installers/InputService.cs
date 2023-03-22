using IceWasteland.Services;
using System;
using UnityEngine;
using Zenject;

public sealed class InputService : IInputService, ITickable
{
    private Vector2 movement;
    
    public Vector2 GetMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        
        return movement;
    }

    public event Action OnInventoryKeyUp;
    public event Action OnInventoryKeyDown;
    public event Action OnShootKeyDown;

    private bool IsShootKeyDown()
        => Input.GetMouseButtonDown(0);

    private bool IsInventoryKeyDown()
        => Input.GetKeyDown(KeyCode.E);

    private bool IsInventoryKeyUp()
        => Input.GetKeyUp(KeyCode.E);

    public void Tick()
    {
        if(IsShootKeyDown())
             OnShootKeyDown?.Invoke();

        if (IsInventoryKeyDown())
            OnInventoryKeyDown?.Invoke();

        if (IsInventoryKeyUp())
            OnInventoryKeyUp?.Invoke();
    }
}