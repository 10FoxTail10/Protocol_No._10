using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;

public class Press_E : MonoBehaviour
{
    public TMP_Text tip;   // UI текст, куда выводится подсказка        #Перевести в один файл#
    public AudioSource audioTV; // Аудио плеер телевизора
    public MeshRenderer videoTV; // Mesh объект телевизора
    public AudioClip soundEffect; // Звуковой эффект подбора вещей
    public GameObject Watch;
    public GameObject Screen;

    private bool _isInRangeTV = false; // Флаг близости к TV
    private bool _isInRange = false; // Флаг близости к объекту
    private bool _screenIsActive = true; // Флаг активности экрана телевизора        #Перевести в один файл#
    private float _startVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))        #Перевести в один файл#
   
    private int _sceneIndex;
    private bool _isExitRange = false;

    public GlobalSet globalSet;

    void Start()
    {
        tip.text = ""; // Базовое значение подсказки для игрока в начале игры
        audioTV.volume = _startVolume; // Изменение на базовое значение звука
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Номер сцены" + _sceneIndex);
    }       //#Перевести в один файл#

    void Update()
    {
        ChangeActiveTV(); //Смена активности TV
        CollectObject(); // Сбор предметов 
        Next(); // Переход на следующий уровень
    }

    #region Change_Active_TV
    private void ChangeActiveTV()
    {
        if (_isInRangeTV && _screenIsActive)
        {
            tip.text = "Нажмите 'E', чтобы выключить";
            if (Input.GetKeyDown(KeyCode.E) && _screenIsActive)
            {
                TurnOffTV();
                _screenIsActive = false;
            }
        }
        else if (_isInRangeTV)
        {
            tip.text = "Нажмите 'E', чтобы включить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOnTV();
                _screenIsActive = true;
            }
        }
        else if (!_isInRangeTV && !_isInRange && !_isExitRange)
        {
            tip.text = ""; // Пустое собщение, чтобы не мешалось на экране)
        }
    }

    private void TurnOffTV()
    {
        audioTV.volume = 0;
        videoTV.enabled = false;
        Screen.SetActive(true);
    }

    private void TurnOnTV()
    {
        audioTV.volume = _startVolume;
        videoTV.enabled = true;
        Screen.SetActive(false);
    }
    #endregion

    #region Exit Next Level

    public void Next()
    {
        if (_isExitRange)
        {
            tip.text = "Нажмите 'E'";
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(_sceneIndex + 1);
            }
        }
    }
    #endregion

    #region Collect
    private void CollectObject()
    {
        if (_isInRange && Watch != null)
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
            _isInRangeTV = true;
        }
        if (other.CompareTag("Watch"))
        {
            _isInRange = true;
        }
        if (other.CompareTag("ExitLV"))
        {
            _isExitRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Screen"))
        {
            _isInRangeTV = false;
        }
        if (other.CompareTag("Watch"))
        {
            _isInRange = false;
        }
        if (other.CompareTag("ExitLV"))
        {
            _isExitRange = false;
        }
    }
    #endregion
}
