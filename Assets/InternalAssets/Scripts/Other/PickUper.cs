using UnityEngine;

public sealed class PickUper : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IPickable pickable))
            pickable.PickUp();
    }
}