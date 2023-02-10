using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovable : MonoBehaviour
{
    private Vector2 movement;
    new private Rigidbody2D rigidbody2D;
    public event Action<Vector2> OnMoved;
    public event Action OnMoveReleased;

    [field: SerializeField] public float MoveSpeed { get; set; } = 5f;
    public bool IsStopped { get; set; } = false;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        if (!IsStopped)
        {
            rigidbody2D.velocity = movement * MoveSpeed;

            if (movement != Vector2.zero)
                OnMoved.Invoke(movement);
        }
        if (IsStopped || movement == Vector2.zero)
            OnMoveReleased.Invoke();
    }
}