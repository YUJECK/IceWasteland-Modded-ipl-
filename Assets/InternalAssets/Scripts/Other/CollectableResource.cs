using AutumnForest.Editor;
using UnityEngine;

public abstract class CollectableResource : MonoBehaviour
{
    [SerializeField, Interface(typeof(IStorable))] protected Object resource;
    public IStorable Resource => resource as IStorable;
}