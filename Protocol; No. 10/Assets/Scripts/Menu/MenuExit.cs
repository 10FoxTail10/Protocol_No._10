using UnityEngine;
using UnityEngine.UI;

public class MenuExit : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] public GameObject menuIsVis;
    [SerializeField] public GameObject menuIsNotVis;
    [SerializeField] public GameObject pause;
    [SerializeField] public VolumeMusic audioAll;

    [Header("Private")]
    [SerializeField] private bool _isActive = false;

    void Update()
    {
        MenuVisible();
    }

    public void MenuVisible()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _isActive)
        {
            menuIsVis.SetActive(false);
            menuIsNotVis.SetActive(true);
            pause.SetActive(true);
            _isActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            menuIsVis.SetActive(true);
            menuIsNotVis.SetActive(false);
            pause.SetActive(false);
            _isActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
