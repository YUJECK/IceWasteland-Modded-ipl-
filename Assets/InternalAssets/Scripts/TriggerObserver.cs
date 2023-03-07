using System;
using UnityEngine;

namespace IceWasteland
{
    public sealed class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> OnTriggerEnter;
        public event Action<Collider2D> OnTriggerExit;

        private void OnTriggerEnter2D(Collider2D collision) => OnTriggerEnter?.Invoke(collision);
        private void OnTriggerExit2D(Collider2D collision) => OnTriggerExit?.Invoke(collision);
    }
}