using UnityEngine;

namespace IceWasteland.AICore
{
    public class Target : MonoBehaviour
    {
        [field: SerializeField] public int Priority { get; private set; }

        public virtual void OnTargeted()
        {
            
        }

        public virtual void OnMissed()
        {
            
        }
    }
}