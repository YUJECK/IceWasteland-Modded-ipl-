using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Projectile : MonoBehaviour
{
    [SerializeField] private bool runOnStart = true;
    [SerializeField] private float defaultProjectileSpeed = 30f;
    public UnityEvent<Collision2D> OnReached { get; } = new();
    public UnityEvent OnShoot { get; } = new();
    
    private new Rigidbody2D rigidbody;

    private void Awake() => rigidbody = GetComponent<Rigidbody2D>();
    private void Start()
    {
        if (runOnStart)
            Run(defaultProjectileSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnReach(collision);
        OnReached.Invoke(collision);
    }

    public virtual void Run(float speed)
    {
        rigidbody.AddForce(transform.up * speed, ForceMode2D.Impulse);
        OnShoot.Invoke();
    }
    protected abstract void OnReach(Collision2D reachedCollision);
}