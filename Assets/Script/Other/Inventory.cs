using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    private readonly List<IStorable> ore = new();
    public readonly UnityEvent<IStorable> OnOreWasAdded = new();

    public void AddOre(IStorable newOre)
    {
        ore.Add(newOre);
        OnOreWasAdded.Invoke(newOre);   
    }
}