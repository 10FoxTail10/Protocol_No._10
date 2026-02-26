using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class Press_E : MonoBehaviour
{
    public TMP_Text tip;   // UI текст, куда выводится подсказка        #Перевести в один файл#
    public AudioSource audioTV; // Аудио плеер телевизора
    public MeshRenderer videoTV; // Mesh объект телевизора
    public AudioClip soundEffect; // Звуковой эффект подбора вещей
    public GameObject Watch;

    private bool isInRangeTV = false; // Флаг близости к TV
    private bool isInRange = false; // Флаг близости к объекту
    private bool screenIsActive = true; // Флаг активности экрана телевизора        #Перевести в один файл#
    private float startVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))        #Перевести в один файл#
    public GlobalSet globalSet;
    void Start()
    {
        tip.text = ""; // Базовое значение подсказки для игрока в начале игры
        audioTV.volume = startVolume; // Изменение на базовое значение звука
    }       //#Перевести в один файл#

    void Update()
    {
        ChangeActiveTV(); //Смена активности TV
        CollectObject(); // Сбор предметов 
        globalSet.assss = 300;
    }

    #region Change_Active_TV
    private void ChangeActiveTV()
    {
        if (isInRangeTV && screenIsActive)
        {
            tip.text = "Нажмите 'E', чтобы выключить";
            if (Input.GetKeyDown(KeyCode.E) && screenIsActive)
            {
                TurnOffTV();
                screenIsActive = false;
            }
        }
        else if (isInRangeTV)
        {
            tip.text = "Нажмите 'E', чтобы включить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnTV();
                screenIsActive = true;
            }
        }
        else if (!isInRangeTV && !isInRange)
        {
            tip.text = ""; // Пустое собщение, чтобы не мешалось на экране)
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

    #region Collect
    private void CollectObject()
    {
        if (isInRange && Watch != null)
        {
            tip.text = "Нажмите 'E'";
            if (Input.GetKeyDown(KeyCode.E))
            {
                CollectWatch();
            }
        }
    }

    private void CollectWatch()
    {
        Destroy(Watch);
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
    }
    #endregion

    #region TriggerTag
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screen"))
        {
            isInRangeTV = true;
        }
        if (other.CompareTag("Watch"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Screen"))
        {
            isInRangeTV = false;
        }
        if (other.CompareTag("Watch"))
        {
            isInRange = false;
        }
    }
    #endregion
}
