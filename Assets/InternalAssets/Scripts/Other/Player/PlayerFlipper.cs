using UnityEngine;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(PlayerMovable))]
    public sealed class PlayerFlipper : MonoBehaviour
    {
        private PlayerMovable playerMove;

        private void Awake()
        {
            playerMove = GetComponent<PlayerMovable>();
        }
        private void OnEnable()
        {
            playerMove.OnMoved += Flip;
        }
        private void OnDisable()
        {
            playerMove.OnMoved -= Flip;
        }

        private void Flip(Vector2 movement)
        {
            if (movement.x < 0 && transform.localScale.x == -1) transform.localScale = new Vector3(1, 1, 1);
            else if (movement.x > 0 && transform.localScale.x == 1) transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}