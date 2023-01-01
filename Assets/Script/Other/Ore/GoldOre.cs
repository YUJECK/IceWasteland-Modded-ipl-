using UnityEngine;

[CreateAssetMenu]
public class GoldOre : Ore
{
    [SerializeField] private int money = 30;

    public override void PickUp()
    {
        base.PickUp();

        GameManager._pointMoney += money;
    }
}