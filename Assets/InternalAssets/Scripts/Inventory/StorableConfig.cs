using System;
using UnityEngine;

namespace IceWasteland.ResourcesCore
{
    [Serializable]
    public sealed class StorableConfig
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
    }
}