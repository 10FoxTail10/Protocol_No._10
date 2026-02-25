using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide : MonoBehaviour
{
    #region Game_Setting
    [Header("Setting")]
    [SerializeField] public GameObject panel;
    
    private bool isVisible = false;
    #endregion

    public void Setting()
    {
        if (isVisible == true)
        {
            isVisible = false;
            panel.SetActive(isVisible);   // Переключаем активность целевого объекта
        }
        else
        {
            isVisible = true;
            panel.SetActive(isVisible);   // Переключаем активность целевого объекта
        }
    }
}
