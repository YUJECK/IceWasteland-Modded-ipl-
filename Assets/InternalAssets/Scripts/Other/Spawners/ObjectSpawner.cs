using Cysharp.Threading.Tasks;
using IceWasteland;
using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 6;
    [SerializeField] private Transform container;
    [SerializeField] private GameObject[] objects;

    private void Start() => Spawning();

    private async void Spawning()
    {
        while (true)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                Vector2 position = GlobalServiceLocator.GetService<SpawnPlace>().GetPosition();
                Instantiate(objects[i], position, Quaternion.identity, container);
            }
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTimer));
        }
    }
}