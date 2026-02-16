using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Press_E : MonoBehaviour
{
    public TMP_Text tip;   // UI текст, куда выводится подсказка
    public AudioSource audioTV; // Аудио плеер объекта
    public MeshRenderer videoTV; // Mesh объект

    private bool isInRange = false; // Флаг близости к объекту
    private bool screenIsActive = true; // Флаг активности экрана
    private float startVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))

    void Start()
    {
        tip.text = ""; // Базовое значение подсказки для игрока в начале игры
        audioTV.volume = startVolume; // Изменение на базовое значение звука
    }

    void Update()
    {
        ChangeActiveTV(); //Смена активности TV
    }

    #region TV
    private void ChangeActiveTV()
    {
        if (isInRange && screenIsActive && hasTV)
        {
            tip.text = "Нажмите 'E', чтобы выключить TV";
            if (Input.GetKeyDown(KeyCode.E) && screenIsActive)
            {
                TurnOffTV();
                screenIsActive = false;
            }
        }
        else if (isInRange && hasTV)
        {
            tip.text = "Нажмите 'E', чтобы включить TV";
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnTV();
                screenIsActive = true;
            }
        }
        else
        {
            tip.text = "";
        }
    }

    private void TurnOffTV()
    {
        audioTV.volume = 0;
        videoTV.enabled = false;
    }

    private void TurnOnTV()
    {
        audioTV.volume = startVolume;
        videoTV.enabled = true;
    }
    #endregion

    #region TriggerTag
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screen"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Screen"))
        {
            isInRange = false;
        }
    }
    #endregion
}

