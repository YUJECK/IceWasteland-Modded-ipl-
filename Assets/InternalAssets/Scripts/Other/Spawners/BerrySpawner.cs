using System.Collections;
using UnityEngine;

public class BerrySpawner : MonoBehaviour
{
    [SerializeField] private GameObject berryPrefab;
    [SerializeField] private Transform spawnPoint;
    private float nextTime = 0f;
    [SerializeField] private float spawnRate = 0f;
    private GameObject berrySpawned; //ягода котора€ заспавнилась

    private void Start()
    {
        StartCoroutine(Respawn());
    }

    private void Update()
    {
        if (berrySpawned == null && GameManager.berrySpawned < GameManager.berryMaxCount && Time.time >= nextTime)
        {
            Spawn();
            GameManager.berrySpawned++;
            nextTime = Time.time + spawnRate + Random.Range(-4f, 4f);
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(160f);
        if (berrySpawned != null) Destroy(berrySpawned);
        StartCoroutine(Respawn());
    }

    private void Spawn()
    {
        if (berrySpawned != null) Destroy(berrySpawned);
        berrySpawned = Instantiate(berryPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}
