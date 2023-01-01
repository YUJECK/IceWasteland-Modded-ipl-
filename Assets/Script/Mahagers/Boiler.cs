using TMPro;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [SerializeField] private int berryCountNeed = 3;
    [SerializeField] private int berryCount = 0;
    [SerializeField] private GameObject jamPrefab;
    [SerializeField] private Transform jamPos;
    [SerializeField] private TextMeshProUGUI berryCountText;
    //—сылки на другие скрипты
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            CookBerryJam();
    }
    private void CookBerryJam()
    {
        berryCount += GameManager.berryCount;
        GameManager.berryCount = 0;
        
        if (berryCount >= berryCountNeed)
        {
            berryCount -= berryCountNeed;
            Instantiate(jamPrefab,
                new Vector3(jamPos.position.x, jamPos.position.y, 0f), Quaternion.identity);
            gameManager.UpdateInventory();
        }
        berryCountText.text = berryCount.ToString() + "/" + berryCountNeed.ToString();
    }
}
