using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideHelps : MonoBehaviour
{
    #region Game_Setting
    [Header("Setting")]
    [SerializeField] public TMP_Text textHelps;
    
    private bool isVisible = false;
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Hide();
        }
    }

    public void Hide()
    {
        if (isVisible == true)
        {
            isVisible = false;
            textHelps.gameObject.SetActive(isVisible);   // Переключаем активность целевого объекта
        }
        else
        {
            isVisible = true;
            textHelps.gameObject.SetActive(isVisible);   // Переключаем активность целевого объекта
        }
    }
}
