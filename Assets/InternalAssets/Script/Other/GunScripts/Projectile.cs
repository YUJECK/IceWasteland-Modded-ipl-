using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : MonoBehaviour
{
    public UnityEvent<Collision2D> OnReached { get; } = new();
    public UnityEvent OnShoot { get; } = new();
    
    private new Rigidbody2D rigidbody;


    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnReach(collision);
        OnReached.Invoke(collision);
    }

    public virtual void Shoot(float speed)
    {
        rigidbody.AddForce(Vector2.up * speed);
        OnShoot.Invoke();
    }
    protected abstract void OnReach(Collision2D reachedCollision);
}