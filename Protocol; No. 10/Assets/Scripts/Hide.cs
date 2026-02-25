using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    // Объект, видимость которого мы будем переключать
    public GameObject targetObject;

    private bool isVisible = false;


    // Метод, выполняемый при нажатии на кнопку
    public void Setting()
    {
        if (isVisible == true)
        {
            isVisible = false;
            targetObject.SetActive(isVisible);   // Переключаем активность целевого объекта
        }
        else
        {
            isVisible = true;
            targetObject.SetActive(isVisible);   // Переключаем активность целевого объекта
        }
    }
}
