using UnityEngine;
using UnityEngine.Events;

public class PlayerMovable : MonoBehaviour
{
    private Vector2 movement;
    new private Rigidbody2D rigidbody2D;
    public readonly UnityEvent<Vector2> OnMove = new();
    
    public float MoveSpeed { get; set; }
    public bool IsStopped { get; set; } 

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if(!IsStopped)
        {
            rigidbody2D.velocity = movement * MoveSpeed;
            OnMove.Invoke(movement);
        }
    }
}