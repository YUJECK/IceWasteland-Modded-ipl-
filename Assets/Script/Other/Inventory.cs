using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private readonly List<Ore> ore = new();
    public readonly UnityEvent OreWasAdded = new();

    public void AddOre(Ore newOre) => ore.Add(newOre);
}