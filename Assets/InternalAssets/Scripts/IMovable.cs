using System;
using UnityEngine;

namespace IceWasteland
{
    public interface IMovable
    {
        event Action<Vector2> OnMoved;
        event Action OnMoveReleased;

        void Move();
    }
}