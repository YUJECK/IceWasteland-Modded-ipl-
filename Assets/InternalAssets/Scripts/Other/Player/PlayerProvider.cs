using IceWasteland.AICore;
using UnityEngine;

namespace IceWasteland.Player
{
    [RequireComponent(typeof(PlayerMovable))]
    [RequireComponent(typeof(PlayerTarget))]
    public sealed class PlayerProvider : MonoBehaviour
    {
        public PlayerMovable PlayerMovable { get; private set; }
        public PlayerTarget Target { get; private set; }

        private void Awake()
        {
            PlayerMovable = GetComponent<PlayerMovable>();
            Target = GetComponent<PlayerTarget>();
        }
    }
}