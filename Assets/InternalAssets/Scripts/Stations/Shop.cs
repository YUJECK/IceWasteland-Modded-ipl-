using System;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace IceWasteland.Shop
{
    public sealed class Shop : MonoBehaviour
    {
        [SerializeField] private GameObject shopUI;
        private SerializedDictionary<string, TradeItemSpawner> items;

        private void Awake()
        {
            
        }

        private void Buy(string id)
        {
            items[id].Sold();
            items.Remove(id);
        }
    }
}