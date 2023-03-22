using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class GoldOre : MonoBehaviour, IPickable
{
    [SerializeField] private int money = 30;
    [SerializeField] GameObject goldDustParticle;

    public event Action OnPickedUp;

    public void PickUp() 
    {
        MoneyManager.AddMoney(30);
        Instantiate(goldDustParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}