using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float _speedFactor;
    [SerializeField] Transform _player;

    [SerializeField] GameObject _effectTeleport;

    [SerializeField] Text _textX;
    [SerializeField] Text _textY;

    [SerializeField] Transform[] _pointStart;
    private int _random;

    private bool _FacingRight;

    public static float _speed = 7f;
    public static Transform _playerPoint;
    private int health = 1;
    [SerializeField] private UnityEvent onDead;
    private int maxHealth = 3;
    public List<GameObject> healthHeart = new List<GameObject>();
    private float inviseCadrsDuration = 4f;
    private float startInviseCadrs;
    [SerializeField] private GameObject healthPrefab;

    private int _xDerect;
    private int _yDerect;

    private float _timeStart = 7f;
    private float _timeShot = 7f;

    Rigidbody2D _rb;
    Vector2 _movement;

    //—сылки на другие скрипты
    private GameManager gameManager;

    void Awake()
    {
        _timeStart = Random.Range(5, 12);
        _timeShot = _timeStart;
        _random = Random.Range(0, _pointStart.Length);
        _speed = _speedFactor;
        _playerPoint = transform;
        _rb = GetComponent<Rigidbody2D>();
        transform.position = _pointStart[_random].transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }
    public int GetHealth() { return health; }
    public void HealthUp(Color heartColor, bool extra = false)
    {
        health++;

        if (extra)
        {
            SouthPickUp._isLive = true;
            healthHeart.Add(Instantiate(healthPrefab,
            new Vector3(healthHeart[healthHeart.Count - 1].transform.position.x + 1f, healthHeart[healthHeart.Count - 1].transform.position.y,
            0f), Quaternion.identity, healthHeart[0].transform.parent));
            GetComponent<MoonDeath>()._heartImage = healthHeart[healthHeart.Count - 1];
            healthHeart[healthHeart.Count - 1].GetComponent<Image>().color = heartColor;
        }
        else if(health <= maxHealth)
        {
            healthHeart.Add(Instantiate(healthPrefab,
            new Vector3(healthHeart[healthHeart.Count - 1].transform.position.x + 1f, healthHeart[healthHeart.Count - 1].transform.position.y,
            0f), Quaternion.identity, healthHeart[0].transform.parent));
            healthHeart[healthHeart.Count - 1].GetComponent<Image>().color = heartColor;
        }
        gameManager.healthCount.text = health + "/" + maxHealth;
    }
    public void HealthDown()
    {
        if (Time.time - startInviseCadrs >= inviseCadrsDuration)
        {
            Debug.Log(health);
            health--;
            Destroy(healthHeart[healthHeart.Count - 1]);
            healthHeart.RemoveAt(healthHeart.Count - 1);
            if (health <= 0) Dead();
            gameManager.healthCount.text = health + "/" + maxHealth;
        }
    }
    public void Dead()
    {
        DeadPlayer._isDead = true;
        onDead.Invoke();
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        _speedFactor = _speed;

        _xDerect = ((int)transform.position.x);
        _yDerect = ((int)transform.position.y);

        _textX.text = _xDerect.ToString() + " :X";
        _textY.text = _yDerect.ToString() + " :Y";

        _playerPoint = _player;

        if (_movement.x < 0 && _FacingRight)
        {
            Flip();
        }
        else if (_movement.x >  0 && !_FacingRight)
        {
            Flip();
        }

        if (GameManager._cosmo >= 1f)
        {
            if (_timeShot <= 0f)
            {
                transform.position = new Vector2(Random.Range(110, -110), Random.Range(70, -25));
                _timeStart = Random.Range(5, 12);
                Instantiate(_effectTeleport, gameObject.transform.position, Quaternion.identity);
                _timeShot = _timeStart;
            }
            else
            {
                _timeShot -= Time.deltaTime;
            }
        }

        _rb.MovePosition(_rb.position +_movement * _speed * Time.fixedDeltaTime);
    }
    void Flip()
    {
        _FacingRight = !_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
