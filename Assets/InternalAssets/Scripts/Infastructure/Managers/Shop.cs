using System;
using AYellowpaper.SerializedCollections;
using InternalAssets.Scripts.Helpers;
using Unity.Mathematics;
using UnityEngine;

public sealed class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;

    [SerializeField] private SerializedDictionary<string, TradeItem> items;

    private void Buy(string id)
    {
        items[id].Sold();
        items.Remove(id);
    }
}

public abstract class TradeItem
{
    public abstract void Sold();
}

[Serializable]
public sealed class TradeItemSpawner : TradeItem
{
    private GameObject _prefab;
    
    public override void Sold()
    {
        var position = RandomPositionGenerator.GetPosition();
        
        GameObject.Instantiate(_prefab, position, quaternion.identity)
    }
} 