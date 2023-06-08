using System;
using InternalAssets.Scripts.Helpers;
using Unity.Mathematics;
using UnityEngine;

namespace IceWasteland.Shop
{
    [Serializable]
    public sealed class TradeItemSpawner : TradeItem
    {
        [SerializeField] private GameObject prefab;
        
        public override void Sold()
        {
            var position = RandomPositionGenerator.GetPosition();

            GameObject.Instantiate(prefab, position, quaternion.identity);
        }
    }
}