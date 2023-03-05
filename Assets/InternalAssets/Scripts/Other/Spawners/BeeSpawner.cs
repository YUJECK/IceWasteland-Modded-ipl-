using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace IceWasteland.Spawners
{
    public sealed class BeeSpawner : MonoBehaviour
    {
        private Bee.BeeFactory factory = new();

        private void Start()
        {
            Spawning();
        }

        private async void Spawning()
        {
            while (true) 
            {
                factory.Create();
                await UniTask.Delay(TimeSpan.FromSeconds(5f));
            }
        }
    }
}