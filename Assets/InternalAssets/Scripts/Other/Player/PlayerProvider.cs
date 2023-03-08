using UnityEngine;

namespace IceWasteland.Player
{
    [RequireComponent(typeof(PlayerMovable))]
    public sealed class PlayerProvider : MonoBehaviour
    {
        public PlayerMovable PlayerMovable { get; private set; }

        private void Awake()
        {
            PlayerMovable = GetComponent<PlayerMovable>();
        }
    }
}