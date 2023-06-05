using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerySheet : MonoBehaviour
{
    //—сылки на другие скрипты
    private GameManager gameManager;

    private void Start() { gameManager = FindObjectOfType<GameManager>(); }
    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Gary") && LutingPlayer._heKeng == false)
        {
            GameManager._uranClear = (int)(GameManager._uranClear * 0.6f);
            GameManager._uran = (int)(GameManager._uran * 0.6f);
            GameManager._metal = (int)(GameManager._metal * 0.6f);
            GameManager._pointUgly = (int)(GameManager._pointUgly * 0.6f); 
            GameManager._horny = (int)(GameManager._horny * 0.6f);
            GameManager._metalBullet = (int)(GameManager._metalBullet * 0.6f);
            GameManager._clearRubin = (int)(GameManager._clearRubin * 0.6f);
            GameManager._rubin = (int)(GameManager._rubin * 0.6f);
            GameManager._terrakota = (int)(GameManager._terrakota * 0.6f);
            GameManager._moon = (int)(GameManager._moon * 0.6f);
            GameManager._moonDirt = (int)(GameManager._moonDirt * 0.6f);
            gameManager.UpdateInventory();
        }
    }
}
