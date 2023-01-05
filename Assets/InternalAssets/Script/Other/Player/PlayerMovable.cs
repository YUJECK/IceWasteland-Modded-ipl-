using UnityEngine;
using UnityEngine.Events;

public class PlayerMovable : MonoBehaviour
{
    private Vector2 movement;
    new private Rigidbody2D rigidbody2D;
    public readonly UnityEvent<Vector2> OnMoved = new();
    public readonly UnityEvent OnMoveReleased = new();

    public float MoveSpeed { get; set; } = 3f;
    public bool IsStopped { get; set; } = false;

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
            OnMoved.Invoke(movement);
        }
        if(IsStopped || movement == Vector2.zero)
            OnMoveReleased.Invoke();
    }
}