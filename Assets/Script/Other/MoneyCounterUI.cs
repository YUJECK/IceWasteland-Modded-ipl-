using UnityEngine;
using UnityEngine.UI;

public sealed class MoneyCounterUI : MonoBehaviour
{
    [SerializeField] private Text moneyCounter;

    private void OnEnable() => MoneyManager.OnMoneyChanged.AddListener(SetMoneyText);
    private void SetMoneyText(int money) => moneyCounter.text = money.ToString();
}