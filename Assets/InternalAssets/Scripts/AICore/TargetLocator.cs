using System;
using UnityEngine;

namespace IceWasteland.AICore
{
    public sealed class TargetLocator : MonoBehaviour
    {
        public event Action<PlayerTarget> OnTargetFound;
        public event Action<PlayerTarget> OnTargetMissed;

        public PlayerTarget CurrentTarget { get; private set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerTarget target))
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