using IceWasteland.Helpers;
using UnityEngine;

namespace IceWasteland.Machines
{
    public sealed class RecycleMachine : MonoBehaviour
    {
        private Inventory inventory;

        private void Awake() => inventory = FindObjectOfType<Inventory>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(TagHelper.Player))
            {
                IRecyclable[] recyclableItems = inventory.GetRecyclableItems(true);

                for (int i = 0; i < recyclableItems.Length; i++)
                    recyclableItems[i].Recycle();
            }
        }
    }
}