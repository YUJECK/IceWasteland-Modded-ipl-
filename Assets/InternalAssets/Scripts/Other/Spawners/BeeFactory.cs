using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace IceWasteland.Spawners
{
    public sealed class BeeFactory : MonoBehaviour
    {
        [SerializeField] private float spawnRate = 2f;
        [SerializeField] private int beesLimit = 15;

        private int currentBeesCount = 0;

        private DiContainer _container = new();
        private Bee _beePrefab;

        [Inject]
        private void Construct(DiContainer container)
            => _container = container;

        public void Start()
        {
            LoadBeePrefab();
            Spawning(this.GetCancellationTokenOnDestroy());
        }

        private void LoadBeePrefab()
        {
            _beePrefab = Resources.Load<Bee>(AssetsPath.BEE);
        }
        private async void Spawning(CancellationToken token)
        {
            while (currentBeesCount <= beesLimit)
            {
                Create();
                await UniTask.Delay(TimeSpan.FromSeconds(spawnRate), cancellationToken: token);
            }
        }
        public Bee Create()
        {
            currentBeesCount++;
            return _container.InstantiatePrefabForComponent<Bee>(_beePrefab, transform.position, Quaternion.identity, null);
        }
    }
}