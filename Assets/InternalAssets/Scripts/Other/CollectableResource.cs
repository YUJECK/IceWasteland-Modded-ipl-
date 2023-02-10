using AutumnForest.Editor;
using UnityEngine;

public abstract class CollectableResource : MonoBehaviour
{
    [SerializeField, Interface(typeof(ICollectable))] protected Object resource;
    public ICollectable Resource => resource as ICollectable;
}