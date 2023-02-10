using UnityEngine;

namespace IceWasteland
{
    public sealed class GlobalServiceRegistrar : MonoBehaviour
    {
        [SerializeField] private SpawnPlace spawnPlace;

        private void Awake()
        {
            GlobalServiceLocator.RegisterService(spawnPlace);
        }
    }
}