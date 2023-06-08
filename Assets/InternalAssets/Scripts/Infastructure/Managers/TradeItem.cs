using UnityEngine;

namespace IceWasteland.Shop
{
    public abstract class TradeItem
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        public abstract void Sold();
    }
}