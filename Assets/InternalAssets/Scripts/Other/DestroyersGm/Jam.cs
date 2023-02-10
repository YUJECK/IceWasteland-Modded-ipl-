using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jam : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            //collision.gameObject.GetComponent<PlayerControl>().HealthUp(Color.red, false);
            Destroy(gameObject);
        }
    }
}
