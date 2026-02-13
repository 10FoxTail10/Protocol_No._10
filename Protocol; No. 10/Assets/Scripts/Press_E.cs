using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Press_E : MonoBehaviour
{
    public GameObject tvObject; // Объект-телевизор
    public TMP_Text messageText;   // UI элемент текста, куда выводится подсказка
    private bool isInRange = false; // Флаг близости к ТВ

    void Update()
    {
        if (isInRange)
        {
            Debug.Log("Вроде бы работатет");
            messageText.text = "Нажмите 'E', чтобы выключить TV";

            if (Input.GetKeyDown(KeyCode.E))
            {
                TurnOffTV();
            }
        }
        else
        {
            messageText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void TurnOffTV()
    {
        tvObject.SetActive(false); // Выключаем телевизор
    }
}
