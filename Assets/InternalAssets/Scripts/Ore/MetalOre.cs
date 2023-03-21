using IceWasteland;
using IceWasteland.ResourcesCore;
using System;
using UnityEngine;
using Zenject;

public class MetalOre : MonoBehaviour, IPickable
{
    public event Action OnPickUp;

    private IInventory inventory;
    private MetalResource metal;

    [Inject]
    public void Construct(IInventory inventory, ResourcesHandler resourcesHandler)
    {
        this.inventory = inventory;
        this.metal = resourcesHandler.Get<MetalResource>() as MetalResource;
    }

    public void PickUp()
    {
        inventory.AddItem(metal);
        Destroy(gameObject);
    }
}