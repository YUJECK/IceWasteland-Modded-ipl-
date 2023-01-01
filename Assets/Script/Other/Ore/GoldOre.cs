using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class GoldOre : ScriptableObject, IPickable
{
    [SerializeField] private int money = 30;

    public UnityEvent OnPickUp { get; private set; }

    public void PickUp() { GameManager._pointMoney += money; Debug.Log("asd"); }
}