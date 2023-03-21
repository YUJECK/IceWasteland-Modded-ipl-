using IceWasteland.Services;
using System;
using UnityEngine;
using Zenject;

namespace IceWasteland.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovable : MonoBehaviour, IMovable
    {
        new private Rigidbody2D rigidbody2D;
        private IInputService inputService;
    
        public event Action<Vector2> OnMoved;
        public event Action OnMoveReleased;

        [field: SerializeField] public float MoveSpeed { get; set; } = 5f;
        public bool IsStopped { get; set; } = false;

        [Inject]
        private void Construct(IInputService inputService)
            => this.inputService = inputService;

        private void Awake() => rigidbody2D = GetComponent<Rigidbody2D>();
        private void FixedUpdate() => Move();

        public void Move()
        {
            if (!IsStopped)
            {
                rigidbody2D.velocity = inputService.GetMovement() * MoveSpeed;

                if (inputService.GetMovement() != Vector2.zero)
                    OnMoved?.Invoke(inputService.GetMovement());
            }
            if (IsStopped || inputService.GetMovement() == Vector2.zero)
                OnMoveReleased?.Invoke();
        }
    }
}