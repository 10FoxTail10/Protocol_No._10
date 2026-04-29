using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;

public class Press_E : MonoBehaviour
{
    #region Variables
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSet _globalSet; // Скрипт с глобальными переменными

    [Header("Door")]
    [SerializeField] private DoorController _currentDoor; // Скрипт с взаимодействием двери (ставится автоматом дальше по коду)
    [SerializeField] private ExitDoorController _currentExitDoor; // Скрипт с взаимодействием двери (ставится автоматом дальше по коду)

    [Header("TV")]
    [SerializeField] public AudioSource audioTV; // Аудио телевизора
    [SerializeField] public MeshRenderer videoTV; // Mesh экрана телевизора (для отображения видео)
    [SerializeField] public GameObject screenOff;
    [SerializeField] public GameObject led;
    [SerializeField] public Material ledMaterialOn;
    [SerializeField] public Material ledMaterialOff;
    [SerializeField] public MeshRenderer ledMesh;
    [SerializeField] private bool _tvIsStatus; // Статус телевизора (вкл/выкл)

    [Header("Item")]
    [SerializeField] public AudioClip soundEffect; // Звуковой эффект подбора вещей

    [Header("Raycast")]
    [SerializeField] private float _distance = 1f;

    //private Ray _ray = new Ray(transform.position, transform.forward);
    public RaycastHit _hit;

    [Header("Seat")]
    [SerializeField] public GameObject person;
    [SerializeField] public GameObject seatPerson;

    [Header("Private")]
    private TMP_Text _tips;
    #endregion

    private float _startVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))        #Перевести в один файл#


    void Start()
    {
        _tips = _globalSet.tips;
        ledMesh = led.GetComponent<MeshRenderer>();
        audioTV.volume = _startVolume; // Изменение на базовое значение звука
    }       //#Перевести в один файл#

    void Update()
    {
        Raycast();
    }

    #region Raycast
    private void Raycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distance))
        {
            if (_hit.collider.CompareTag("Door"))
            {
                Door(); // Открытие закрытие двери
            }
            ChangeActiveTV(); // Смена активности TV
            CollectObject(); // Сбор предметов 
            Seat(); // Сесть
        }
        else
        {
            _tips.text = "";
        }
    }
    #endregion

    #region Door
    private void Door()
    {
        if (_hit.collider.CompareTag("Door"))
        {
            _currentDoor = _hit.collider.GetComponent<DoorController>();
            _currentDoor.ChangeStatusDoor();
        }
        else if (_hit.collider.CompareTag("Exit"))
        {
            _currentExitDoor = _hit.collider.GetComponent<ExitDoorController>();
            _currentExitDoor.NextLV();
        }
        else
        {
            _currentDoor = null;
        }
    }

    #endregion

    #region TV
    private void ChangeActiveTV()
    {
        if (_hit.collider.CompareTag("Mechanism") && !_tvIsStatus)
        {
            _tips.text = "Нажмите 'E', чтобы включить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnTV();
                _tvIsStatus = true;
                ledMesh.material = ledMaterialOn;
            }
        }
        else if (_hit.collider.CompareTag("Mechanism") && _tvIsStatus)
        {
            _tips.text = "Нажмите 'E', чтобы выключить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOffTV();
                _tvIsStatus = false;
                ledMesh.material = ledMaterialOff;
            }
        }
    }

    private void TurnOnTV()
    {
        audioTV.volume = _startVolume;
        videoTV.enabled = true;
        screenOff.SetActive(false);
    }

    private void TurnOffTV()
    {
        audioTV.volume = 0;
        videoTV.enabled = false;
        screenOff.SetActive(true);
    }

    #endregion

    #region Items
    private void CollectObject()
    {
        if (_hit.collider.CompareTag("Item"))
        {
            _tips.text = "Нажмите 'E', чтобы подобрать";
            if (Input.GetKeyDown(KeyCode.E))
            {
                CollectWatch();
            }
        }
    }

    private void CollectWatch()
    {
        Destroy(_hit.collider.gameObject);
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        _tips.text = "";
    }
    #endregion

    #region Seat
    private void Seat()
    {
        if (_hit.collider.CompareTag("Seat"))
        {
            _tips.text = "Нажмите 'E', чтобы сесть";
            if (Input.GetKeyDown(KeyCode.E))
            {
                seatPerson.SetActive(true);
                person.SetActive(false);
            }
        }
    }
    #endregion

}
