using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagazineWorkest : MonoBehaviour
{
    [SerializeField] GameObject _petHappy;
    [SerializeField] GameObject _petNormal;
    [SerializeField] GameObject _petSad;

    [SerializeField] GameObject _trecker;

    [Header("DereactPost")]
    [SerializeField] GameObject _panelSpeed;
    [SerializeField] GameObject _panelRadiation;
    [SerializeField] GameObject _panelNormal;
    [SerializeField] GameObject _panelBig;
    [SerializeField] GameObject _panelGun;
    [SerializeField] GameObject _panelID;
    [SerializeField] GameObject _panelPet;

    [Header("Posters")]
    [SerializeField] GameObject _postSpeed;
    [SerializeField] GameObject _postRadiation;
    [SerializeField] GameObject _postNormalInvenore;
    [SerializeField] GameObject _postBigInventore;
    [SerializeField] GameObject _postGun;
    [SerializeField] GameObject _postPet;
    [SerializeField] GameObject _postID;

    [SerializeField] AudioSource _buySound;
    [SerializeField] AudioSource _noteSound;

    public static bool _speedSold = false;
    public static bool _radiationSold = false;
    public static bool _inventoreNormalSold = false;
    public static bool _inventoreBigSold = false;
    public static bool _petSold = false;
    public static bool _gunSold = false;
    public static bool _idSold = false;
    public static bool _treckerSold = false;

    //Ссылки на другие компоненты
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void BuyRadiation()
    {
        if (GameManager._pointMoney >= 275f)
        {
            GameManager._pointMoney -= 275f;
            _postRadiation.SetActive(true);
            _panelRadiation.SetActive(true);
            _buySound.Play();
            _radiationSold = true;            
            StartCoroutine(WriteNotes("Противорадиационный костюм", _postRadiation.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuySpeed()
    {
        if (GameManager._pointMoney >= 150f)
        {
            GameManager._pointMoney -= 150f;
            _postSpeed.SetActive(true);
            _panelSpeed.SetActive(true);
            _buySound.Play();
            _speedSold = true;
            StartCoroutine(WriteNotes("Повышение скорости", _postSpeed.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuyNormalInventore()
    {
        if (GameManager._pointMoney >= 180f)
        {
            GameManager._pointMoney -= 180f;
            _postNormalInvenore.SetActive(true);
            _panelNormal.SetActive(true);
            _buySound.Play();
            _inventoreNormalSold = true;
            StartCoroutine(WriteNotes("Рюкзак", _postNormalInvenore.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuyBigInventore()
    {
        if (GameManager._pointMoney >= 300f)
        {
            GameManager._pointMoney -= 300f;
            _postBigInventore.SetActive(true);
            _panelBig.SetActive(true);
            _buySound.Play();
            _inventoreBigSold = true;
            StartCoroutine(WriteNotes("Большой рюкзак", _postBigInventore.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuyPet()
    {
        if (GameManager._pointMoney >= 50f)
        {
            GameManager._pointMoney -= 50f;
            _postPet.SetActive(true);
            _panelPet.SetActive(true);
            _buySound.Play();
            _petSold = true;
            Debug.Log(_panelPet.transform.position);
            StartCoroutine(WriteNotes("Питомец", _postPet.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuyGun()
    {
        if (GameManager._pointMoney >= 250f)
        {
            GameManager._pointMoney -= 250f;  
            _postGun.SetActive(true);
            _panelGun.SetActive(true);
            _buySound.Play();         
            _gunSold = true;
            StartCoroutine(WriteNotes("Ружьё", _postGun.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuyID()
    {
        if (GameManager._pointMoney >= 200f)
        {
            GameManager._pointMoney -= 200f;
            _postID.SetActive(true);
            _panelID.SetActive(true);  
            _buySound.Play();         
            _idSold = true;
            StartCoroutine(WriteNotes("Карточка охотника", _postID.transform));
            gameManager.UpdateInventory();
        }
    }

    public void BuyTreker()
    {
        if (GameManager._pointMoney >= 100f)
        {
            GameManager._pointMoney -= 100f; 
            _trecker.SetActive(true);
            _buySound.Play();         
            _treckerSold = true;
        }
    }

    private IEnumerator WriteNotes(string itemName, Transform objTransform)
    {
        yield return new WaitForSeconds(2f);
        //gameManager.notes.Add(new Note(
        //    Instantiate(gameManager.notes[0].noteText.gameObject,
        //    new Vector3(gameManager.notes[0].noteText.transform.position.x,
        //    gameManager.notes[gameManager.notes.Count-1].noteText.transform.position.y - 1f, 0f), Quaternion.identity,
        //    gameManager.notes[0].noteText.transform.parent).GetComponent<Text>(),
        //    itemName, objTransform.position));
        _noteSound.Play();
        gameManager.newIndicator.SetActive(true);
    }    

    public void ExitMagazine()
    {
        LutingPlayer._isMagazineOpen = false;
        Time.timeScale = 1;
    }
}
