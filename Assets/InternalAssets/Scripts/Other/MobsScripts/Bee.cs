using IceWasteland.AICore;
using UnityEngine;
using Zenject;

namespace IceWasteland.AICore
{
    [RequireComponent(typeof(TargetLocator))]
    public class Bee : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private PointTarget[] _targetPoints;
        private int _randomPoint;
        
        private TargetLocator _targetLocator;
        
        private Target Target => _targetLocator.CurrentTarget;
        
        [Inject]
        public void Construct(PointTarget[] targetPoints)
        {
            this._targetPoints = targetPoints;
            RandomizePoint();
        }

        private void Start()
            => _targetLocator = GetComponent<TargetLocator>();

        private void FixedUpdate()
        {
            if (Target != null)
                Move(Target.transform);
            else if (_targetPoints[_randomPoint] != null && _targetPoints[_randomPoint].transform.position != transform.position)
                Move(_targetPoints[_randomPoint].transform);
            else
                RandomizePoint();
        }

        private void Move(Transform target)
           => transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        private void RandomizePoint()
            => _randomPoint = Random.Range(0, _targetPoints.Length);
    }
}
