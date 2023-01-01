using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] GameObject _effect;

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (_effect != null) Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (_coll.gameObject.CompareTag("Sold") || _coll.gameObject.CompareTag("Raport") || _coll.gameObject.CompareTag("Magas"))
            Destroy(gameObject);
    }
}
