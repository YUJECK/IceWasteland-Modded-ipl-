using System;
using UnityEngine;

namespace IceWasteland.ResourcesCore
{
    [Serializable]
    public sealed class StorableConfig
    {
        [SerializeField] public Sprite Icon { get; private set; }
        [SerializeField] public string Name { get; private set; }
    }
}