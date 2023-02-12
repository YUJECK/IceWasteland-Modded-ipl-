using Cysharp.Threading.Tasks;
using IceWasteland.Helpers;
using UnityEngine;

namespace IceWasteland
{
    public sealed class MonoRotator : MonoBehaviour
    {
        [SerializeField] private TransformRotation.RotateType rotateType;
        [SerializeField] private Transform target;
        [SerializeField] private bool asPlayer;
        
        [SerializeField] private float coefficent = 1;

        public TransformRotation.RotateType RotateType => rotateType;
        public TransformRotation TransfromRotation { get; private set; }


        private void Awake()
        {
            if (asPlayer)
                target = GameObject.FindGameObjectWithTag(TagHelper.Player).transform;

            TransfromRotation = new(transform, target, coefficent, rotateType, this.GetCancellationTokenOnDestroy());
        }
        private void OnEnable() => TransfromRotation.Enable();
        private void OnDisable() => TransfromRotation.Disable();

        private void OnValidate()
        {
            if(TransfromRotation != null)
            {
                TransfromRotation.Coefficient = coefficent;
                TransfromRotation.RotationType= rotateType;
            }
        }
    }
}