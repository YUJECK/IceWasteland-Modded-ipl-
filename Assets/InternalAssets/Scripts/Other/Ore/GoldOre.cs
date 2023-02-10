using UnityEngine;
using UnityEngine.Events;

public sealed class GoldOre : MonoBehaviour, IPickable
{
    [SerializeField] private int money = 30;
    [SerializeField] GameObject goldDustParticle;
    public UnityEvent OnPickUp { get; private set; }

    public void PickUp() 
    {
        MoneyManager.AddMoney(30);
        Instantiate(goldDustParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}