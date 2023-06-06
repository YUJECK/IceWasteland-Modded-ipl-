using UnityEngine;

namespace InternalAssets.Scripts.Helpers
{
    public static class RandomPositionGenerator
    {
        public static Vector2 GetPosition()
        {
            var position = GetRandomPosition();
            var hit = Physics2D.Raycast(position, Vector2.zero);

            while (hit.collider != null)
            {
                position = GetRandomPosition();
                hit = Physics2D.Raycast(position, Vector2.zero);
            }

            return position;
        }

        private static Vector2 GetRandomPosition()
        {
            var rightDownCorner = new Vector2(-97, -73);
            var leftUpCorner = new Vector2(104f, 3f);

            var x = Random.Range(leftUpCorner.x, rightDownCorner.x);
            var y = Random.Range(rightDownCorner.y, leftUpCorner.y);
            
            return new Vector2(x, y);
        }
    }
}