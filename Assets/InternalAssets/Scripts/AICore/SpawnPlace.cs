using System;
using UnityEngine;

namespace IceWasteland
{
    [Serializable]
    public sealed class SpawnPlace
    {
        int layer = 0 << 2;

        [SerializeField] private Vector2 leftDownCorner;
        [SerializeField] private Vector2 rightUpCorner;

        public SpawnPlace(Vector2 leftDownCorner, Vector2 rightUpCorner)
        {
            this.leftDownCorner = leftDownCorner;
            this.rightUpCorner = rightUpCorner;
        }

        public Vector2 GetPosition()
        {
            while (true)
            {
                if(!ContaintsColliders(GetHits(out Vector2 position)))
                    return position;
            }
        }

        private RaycastHit2D[] GetHits(out Vector2 position)
        {
            position = new Vector2(UnityEngine.Random.Range(leftDownCorner.x, rightUpCorner.x),
                                          UnityEngine.Random.Range(leftDownCorner.y, rightUpCorner.y));
            return Physics2D.RaycastAll(position, Vector2.zero, ~layer);
        }
        private bool ContaintsColliders(RaycastHit2D[] hits)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider != null)
                    return true;
            }

            return false;
        }
    }
}