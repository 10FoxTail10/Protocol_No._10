using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSet _globalSet; // Скрипт с глобальными переменными
    [SerializeField] private Press_E _press_E; // Скрипт с глобальными переменными

    [Header("Door")]
    [SerializeField] public AudioClip soundDoor; // Звуковой эффект двери
    [SerializeField] private bool _doorIsStatus; // Статус двери (открыто/закрыто)

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitDoor;

    void Start()
    {
        _tips = _globalSet.tips;
        _hitDoor = _press_E._hit;
    }

    public void ChangeStatusDoor()
    {
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
        Animator anim = _hitDoor.transform.GetComponent<Animator>();
        anim.SetBool("Open", !anim.GetBool("Open"));
    }

    private void DoorClose()
    {
        Animator anim = _hitDoor.transform.GetComponent<Animator>();
        anim.SetBool("Close", !anim.GetBool("Close"));
    }

}
