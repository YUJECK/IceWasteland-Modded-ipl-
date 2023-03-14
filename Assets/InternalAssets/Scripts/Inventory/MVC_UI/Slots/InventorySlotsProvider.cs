using IceWasteland.Extensions;
using System.Collections.Generic;
using UnityEngine;

public sealed class InventorySlotsProvider : MonoBehaviour
{
    private InventorySlot[] slots;

    private void Awake() => slots = GetComponentsInChildren<InventorySlot>();  

    public List<InventorySlot> Get()
    {
        return new List<InventorySlot>()
            .WriteFromArray(slots);
    }
}