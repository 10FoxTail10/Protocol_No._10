using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PressE : MonoBehaviour
{
    #region Variables
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными

    [Header("Door")]
    [SerializeField] private DoorController _doorController; // Скрипт с взаимодействием двери (ставится автоматом дальше по коду)
    [SerializeField] private ExitDoorController _exitDoorController; // Скрипт с взаимодействием двери (ставится автоматом дальше по коду)

    [Header("TV")]
    [SerializeField] public AudioSource audioTV; // Аудио телевизора
    [SerializeField] public MeshRenderer videoTV; // Mesh экрана телевизора (для отображения видео)
    [SerializeField] public GameObject screenOff;
    [SerializeField] public GameObject led;
    [SerializeField] public Material ledMaterialOn;
    [SerializeField] public Material ledMaterialOff;
    [SerializeField] public MeshRenderer ledMesh;
    [SerializeField] private bool _tvIsStatus = true; // Статус телевизора (вкл/выкл)

    [Header("Item")]
    [SerializeField] private PickupItem _pickupItem; // Скрипт с подбором предметов (ставится автоматом дальше по коду)

    [Header("Raycast")]
    [SerializeField] public RaycastHit _hit;
    [SerializeField] private float _distance = 3f;
    public Ray ray;

    [Header("Seat")]
    [SerializeField] public GameObject person;
    [SerializeField] public GameObject seatPerson;

    [Header("Private")]
    private TMP_Text _tips;
    #endregion

    private float _startVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))        #Перевести в один файл#


    void Start()
    {
        _tips = _globalSetting.tips;
        ledMesh = led.GetComponent<MeshRenderer>();
        audioTV.volume = _startVolume; // Изменение на базовое значение звука
    }       //#Перевести в один файл#

    void Update()
    {
        Raycast();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
    }

    #region Raycast
    public void Raycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _distance))
        {
            Door(); // Открытие закрытие двери
            if (_hit.collider.CompareTag("Mechanism"))
            {
                ChangeActiveMechanism(); // Смена активности TV
            }
            else if (_hit.collider.CompareTag("Item"))
            {
                CollectObject(); // Сбор предметов 
            }
            else if (_hit.collider.CompareTag("Seat"))
            {
                Seat(); // Сесть
            }
        }
        else
        {
            _tips.text = "";
        }
    }
    #endregion

    #region Door
    public void Door()
    {
        if (_hit.collider.CompareTag("Door"))
        {
            _doorController = _hit.collider.GetComponent<DoorController>();
            _doorController.ChangeStatusDoor();
        }
        else if (_hit.collider.CompareTag("Exit"))
        {
            _exitDoorController = _hit.collider.GetComponent<ExitDoorController>();
            _exitDoorController.NextLV();
        }
        else
        {
            _doorController = null;
            _exitDoorController = null;
        }
    }

    #endregion

    #region TV
    private void ChangeActiveMechanism()
    {
        if (!_tvIsStatus)
        {
            _tips.text = "Нажмите 'E', чтобы включить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnTV();
                _tvIsStatus = true;
                ledMesh.material = ledMaterialOn;
            }
        }
        else if (_tvIsStatus)
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
        _pickupItem = _hit.collider.GetComponent<PickupItem>();
        _pickupItem.SelectionItem();
    }

    #endregion

    #region Seat
    private void Seat()
    {
        _tips.text = "Нажмите 'E', чтобы сесть";
        if (Input.GetKeyDown(KeyCode.E))
        {
            seatPerson.SetActive(true);
            person.SetActive(false);
        }
    }
    #endregion

}
