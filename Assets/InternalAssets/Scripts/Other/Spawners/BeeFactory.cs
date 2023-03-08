using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace IceWasteland.Spawners
{
    public sealed class BeeFactory : MonoBehaviour
    {
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
            while (true)
            {
                Create();
                await UniTask.Delay(TimeSpan.FromSeconds(5f), cancellationToken: token);
            }
        }
        public Bee Create()
            => _container.InstantiatePrefabForComponent<Bee>(_beePrefab, transform.position, Quaternion.identity, null);
    }
}