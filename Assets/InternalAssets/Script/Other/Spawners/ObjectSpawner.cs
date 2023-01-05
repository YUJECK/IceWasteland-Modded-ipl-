using Cysharp.Threading.Tasks;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private int spawnTimer = 6000;

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
                Vector2 position = new Vector2(Random.Range(minimum.x, maximum.x), Random.Range(minimum.y, maximum.y));
                Instantiate(objects[i], position, Quaternion.identity);
            }
            await UniTask.Delay(spawnTimer);
        }
    }
}