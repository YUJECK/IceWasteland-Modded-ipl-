using AutumnForest.Editor;
using UnityEngine;
using UnityEngine.Events;

public class IronOre : MonoBehaviour, IPickable
{
    [SerializeField, Interface(typeof(IStorable))] private Object iron;

    public IStorable Iron => iron as IStorable;

    public UnityEvent OnPickUp { get; private set; }


    public void PickUp() 
    {
        
    }
}