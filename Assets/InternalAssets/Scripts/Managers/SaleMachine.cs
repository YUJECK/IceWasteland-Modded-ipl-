using IceWasteland.Helpers;
using UnityEngine;

public class SaleMachine : MonoBehaviour
{
    private Inventory inventory;

    private void Awake() => inventory = FindObjectOfType<Inventory>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagHelper.Player))
        {
            ISellable[] recyclableItems = inventory.GetSellableItems(true);

            for (int i = 0; i < recyclableItems.Length; i++)
            {
                recyclableItems[i].OnSold?.Invoke();
                MoneyManager.AddMoney(recyclableItems[i].Cost);

                Debug.Log(recyclableItems[i].Cost);
            }
        }
    }
}