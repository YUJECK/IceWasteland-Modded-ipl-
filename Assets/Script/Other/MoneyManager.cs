using System.Collections;
using UnityEngine;

namespace Assets.Script.Other
{
    public class MoneyManager : MonoBehaviour
    {
        private int money;

        private void AddMoney(int addMoney)
        {
            if(addMoney > 0)
                money += addMoney;
        }
        private void TakeAwayMoney(int awayMoney)
        {
            if(awayMoney > 0)
                money -= awayMoney;

        }
    }
}