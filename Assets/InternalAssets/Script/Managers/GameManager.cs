using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _panelPause;


    [SerializeField] GameObject _deadPanel;

    [SerializeField] AudioSource _gameTheme;
    [SerializeField] AudioSource _wind;
    [SerializeField] AudioSource _pauseTheme;

    public static bool _isPaused = false;

    public static float _pointMoney = 20f;

    public static float _pointUgly = 0f;
    public static float _porohPoint = 0f;

    public static float _inventor = 0f;
    public static float _limitInventore = 10f;

    public static float _uran = 0f;
    public static float _uranClear = 0f;
    public static float _uranRadiation = 0f;
    public static float _uranNormalRadiation;

    public static float _horny = 0f;

    public static float _metal = 0f;
    public static float _metalBullet = 0f;

    public static float _rubin = 0f;
    public static float _clearRubin = 0f;

    public static float _cosmo = 0f;

    public static float _terrakota = 0f;

    public static float _moon = 0f;
    public static float _moonDirt = 0f;

    //¬с€кие св€занное с €годами
    public static int berryCount = 0; //—колько €год у игрока
    public static int berrySpawned = 0; //—колько €год сейчас заспавнено
    public static int berryMaxCount = 16; //—колько €год может максимум заспавнитьс€

    [SerializeField] GameObject _limitTexti;

    [Header("MoneyText")]
    public Text _moneyText;
    public Text _twoMoneyText;
    public Text _treeMoneyText;

    [Header("Inventore")]
    public Text _inventoreText;
    public Text _inventoreGameText;
    public Text _limitText;
    public Text _limitGameText;

    [Header("Uglys")]
    public Text _uglyText;
    public Text _porohText;

    [Header("Uranys")]
    public Text _uranText;
    public Text _claerUranText;
    public Text _radiathionText;

    [Header("Hornys")]
    public Text _hornyText;

    [Header("Metal")]
    public Text _metalText;
    public Text _inInventBullet;
    public Text _bulletText;

    [Header("Rubin")]
    public Text _rubinText;
    public Text _clearRubinText;

    [Header("Cosmo")]
    public Text _cosmoText;

    [Header("Terrakota")]
    public Text _terrakotaText;

    [Header("Moon")]
    public Text _moonText;
    public Text _moonDirtText;
    [Header("Berry")]
    public Text berryText;
    public Text healthCount;

    [SerializeField] private Text Fps;
    public GameObject newIndicator;

    void Start()
    {
        Time.timeScale = 1;

        _uranNormalRadiation = _uranRadiation;

        _isPaused = false;

        _pointMoney = 20f;

        //PlayerControl._speed = 7f;

        _horny = 0f;
        _metal = 0f;
        _metalBullet = 0f;
        _inventor = 0f;
        _limitInventore = 10f;
        _uran = 0f;
        _uranClear = 0f;
        _pointUgly = 0f;
        _porohPoint = 0f;
        _uranNormalRadiation = 0f;
        _uranRadiation = 0f;
        _clearRubin = 0f;
        _rubin = 0f;
        _cosmo = 0f;
        _terrakota = 0f;
        _moon = 0f;
        _moonDirt = 0f;
        berryCount = 0;

        MagazineWorkest._gunSold = false;
        MagazineWorkest._inventoreBigSold = false;
        MagazineWorkest._inventoreNormalSold = false;
        MagazineWorkest._petSold = false;
        MagazineWorkest._radiationSold = false;
        MagazineWorkest._speedSold = false;
        MagazineWorkest._idSold = false;
        MagazineWorkest._treckerSold = false;

        //PostScript._idIsYou = false;

        LutingPlayer._heKeng = false;
        UpdateInventory();
    }
    void Update()
    {
        //¬ключение счетчика фпс
        if (Input.GetKeyDown(KeyCode.Tab)) Fps.gameObject.SetActive(!Fps.gameObject.activeSelf);
        if (Fps.gameObject.activeSelf)
            Fps.text = "Fps: " + ((int)(1f / Time.unscaledDeltaTime)).ToString();

        if (_inventor == _limitInventore)
            _inventor = _limitInventore;

        if (DeadPlayer._isDead == true)
        {
            _deadPanel.SetActive(true);
            _gameTheme.Stop();
        }

        if (_pointMoney >= 1225)
            SceneManager.LoadScene(2);

        if (_pointMoney <= -1f)
            _pointMoney = 0f;

        if (_inventor >= _limitInventore)
            _limitTexti.SetActive(true);
        else if (_inventor < _limitInventore)
            _limitTexti.SetActive(false);

        if (Input.GetKey(KeyCode.Escape) && LutingPlayer._isMagazineOpen == false && DeadPlayer._isDead == false && ManagerInvent._inventorOpen == false)
        {
            _panelPause.SetActive(true);
            _isPaused = true;
            _gameTheme.volume = 0;
            _wind.volume = 0;
            _pauseTheme.volume = 0.671f;
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown(KeyCode.F8)) { SceneManager.LoadScene(1); }
    }

    //ћетод дл€ кнопок
    public void SetActive(GameObject obj) { obj.SetActive(!obj.activeSelf); }
    public void FlipTimeScale() { if (Time.timeScale == 0f) Time.timeScale = 1f; else if (Time.timeScale == 1f) Time.timeScale = 0f; }
    public void UpdateInventory()
    {
        //ќбновление счетчиков в инвенторе
        GameManager._inventor = GameManager._pointUgly + GameManager._porohPoint
        + GameManager._uran + GameManager._uranClear + GameManager._horny + GameManager._metal + GameManager._rubin + GameManager._clearRubin
        + GameManager._cosmo + GameManager._terrakota + GameManager._moon + GameManager._moonDirt + GameManager.berryCount;
        _inventoreText.text = _inventor.ToString();
        _inventoreGameText.text = _inventor.ToString();
        _limitText.text = _limitInventore.ToString();
        _limitGameText.text = _limitInventore.ToString();

        _uglyText.text = _pointUgly.ToString();
        _porohText.text = _porohPoint.ToString();

        _uranText.text = _uran.ToString();
        _claerUranText.text = _uranClear.ToString();
        _radiathionText.text = _uranRadiation.ToString();

        _hornyText.text = _horny.ToString();

        _metalText.text = _metal.ToString();
        _bulletText.text = _metalBullet.ToString();
        _inInventBullet.text = _metalBullet.ToString();

        _rubinText.text = _rubin.ToString();
        _clearRubinText.text = _clearRubin.ToString();

        _cosmoText.text = _cosmo.ToString();

        _terrakotaText.text = _terrakota.ToString();

        _moonText.text = _moon.ToString();
        _moonDirtText.text = _moonDirt.ToString();

        berryText.text = berryCount.ToString();

        _moneyText.text = _pointMoney.ToString();
        _twoMoneyText.text = _pointMoney.ToString();
        _treeMoneyText.text = _pointMoney.ToString();
    }
}
