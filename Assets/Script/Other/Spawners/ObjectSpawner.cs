using System.Threading.Tasks;
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
                gameObject.transform.position = new Vector2(Random.Range(minimum.x, minimum.y), Random.Range(maximum.x, maximum.y));
                Instantiate(objects[i], gameObject.transform.position, Quaternion.identity);
            }
            await Task.Delay(spawnTimer);
        }
    }
}