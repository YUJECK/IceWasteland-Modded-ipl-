using UnityEngine;

public class CollisionPickUp : MonoBehaviour
{
    [SerializeField] private Object pickableObject;
    private IPickable pickable;

    private void OnValidate()
    {
        if (pickableObject is IPickable)
            pickable = pickableObject as IPickable;
        else pickableObject = null;
    }
    private void OnCollisionEnter2D(Collision2D collision) => pickable?.PickUp();
}