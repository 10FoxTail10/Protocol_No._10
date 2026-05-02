using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE;

    [Header("Door")]
    [SerializeField] public AudioClip soundDoor; // Звуковой эффект двери
    [SerializeField] public Animator anim;
    [SerializeField] private bool _doorIsStatus; // Статус двери (открыто/закрыто)

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitDoor;

    void Start()
    {
        _tips = _globalSetting.tips;
    }

    public void ChangeStatusDoor()
    {
        _hitDoor = _pressE._hit;
        if (!_doorIsStatus)
        {
            _tips.text = "Нажмите 'E', чтобы открыть";
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorOpen();
                _doorIsStatus = true;
            }
        }
        else
        {
            _tips.text = "Нажмите 'E', чтобы закрыть";
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorClose();
                _doorIsStatus = false;
            }
        }
    }

    private void DoorOpen()
    {
        anim = _hitDoor.transform.GetComponent<Animator>();
        anim.SetBool("Open", !anim.GetBool("Open"));
    }

    private void DoorClose()
    {
        anim = _hitDoor.transform.GetComponent<Animator>();
        anim.SetBool("Close", !anim.GetBool("Close"));
    }

}
