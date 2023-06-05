using System;
using UnityEngine;

namespace IceWasteland.AICore
{
    public sealed class TargetLocator : MonoBehaviour
    {
        public event Action<Target> OnTargetFound;
        public event Action<Target> OnTargetMissed;

        public Target CurrentTarget { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Target target))
            {
                CurrentTarget = target;
                OnTargetFound?.Invoke(target);
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (CurrentTarget != null && CurrentTarget.gameObject == collision.gameObject)
            {
                OnTargetMissed?.Invoke(null);
                CurrentTarget = null;
            }
        }
    }
}