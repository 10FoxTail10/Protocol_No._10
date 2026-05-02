using UnityEngine;
using UnityEngine.UI;

public class HidePanel : MonoBehaviour
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
