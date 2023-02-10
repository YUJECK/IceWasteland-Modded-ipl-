using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 6;

    [SerializeField] private Vector2 minimum;
    [SerializeField] private Vector2 maximum;

    [SerializeField] private GameObject[] objects;

    private void Start() => Spawning();

    private async void Spawning()
    {
        while (true)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                Vector2 position = new Vector2(
                    UnityEngine.Random.Range(minimum.x, maximum.x), 
                    UnityEngine.Random.Range(minimum.y, maximum.y));
                
                Instantiate(objects[i], position, Quaternion.identity);
            }
            await UniTask.Delay(TimeSpan.FromSeconds(spawnTimer));
        }
    }
}