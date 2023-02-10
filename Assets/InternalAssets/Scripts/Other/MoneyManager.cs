using UnityEngine;
using UnityEngine.Events;

public static class MoneyManager 
{
    private static int money;
    public static readonly UnityEvent<int> OnMoneyChanged = new();

    //mb нужно доработать
    public static void AddMoney(int addMoney)
    {
        if (addMoney > 0)
        { 
            money += addMoney;
            OnMoneyChanged.Invoke(money);
        } 
        else Debug.LogError("Add money < 0");
    }
    public static void Pay(int moneyPayment)
    {
        if (moneyPayment > 0 && money - moneyPayment >= 0)
        {
            money -= moneyPayment;
            OnMoneyChanged.Invoke(money);
        }
        else if (moneyPayment < 0) Debug.LogError("Payment < 0");
    }
}