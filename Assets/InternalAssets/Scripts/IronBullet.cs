using UnityEngine;

namespace Assets.InternalAssets.Script
{
    public class IronBullet : Projectile
    {
        [SerializeField] private int bulletDamage = 1;

        protected override void OnReach(Collision2D reachedCollision)
        {
            if (reachedCollision.gameObject.TryGetComponent(out IHealth health))
                health.ApplyDamage(bulletDamage);
        }
    }
}