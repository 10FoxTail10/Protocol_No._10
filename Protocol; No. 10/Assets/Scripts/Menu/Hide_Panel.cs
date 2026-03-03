using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hide_panel : MonoBehaviour
{
    [Header("Is Visible")]
    [SerializeField] public GameObject panelIsVisidle;
    [SerializeField] public GameObject panelIsNotVisidle;

    public void PanelVisible()
    {
        panelIsVisidle.SetActive(true);
        panelIsNotVisidle.SetActive(false);
    }
}
