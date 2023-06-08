using System.Collections;
using IceWasteland.AICore;
using UnityEngine;
using Zenject;

namespace IceWasteland.Spawners
{
    public sealed class BeeFactory : MonoBehaviour
    {
        [SerializeField] private float spawnRate = 2f;
        [SerializeField] private int beesLimit = 15;

        private int _currentBeesCount = 0;

        private DiContainer _container = new();
        private Bee _beePrefab;

        [Inject]
        private void Construct(DiContainer container)
            => _container = container;

        public void Start()
        {
            LoadBeePrefab();
            StartCoroutine(Spawning());
        }

        private void LoadBeePrefab()
        {
            _beePrefab = Resources.Load<Bee>(AssetsPath.Bee);
        }
        private IEnumerator Spawning()
        {
            while (_currentBeesCount <= beesLimit)
            {
                Create();
                yield return new WaitForSeconds(spawnRate);
            }
        }
        public Bee Create()
        {
            _currentBeesCount++;
            return _container.InstantiatePrefabForComponent<Bee>(_beePrefab, transform.position, Quaternion.identity, null);
        }
    }
}