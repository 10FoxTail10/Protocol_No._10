using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoorController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с глобальными переменными

    [Header("Door")]
    [SerializeField] public AudioClip soundDoor; // Звуковой эффект двери

    [Header("Next Level")]
    [SerializeField] private int _sceneIndex;

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitDoor;

    void Start()
    {
        _tips = _globalSetting.tips;
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Номер сцены" + _sceneIndex);
    }

    public void NextLV()
    {
        _hitDoor = _pressE._hit;
        _tips.text = "Нажмите 'E', чтобы выйти";
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(_sceneIndex + 1);
        }
    }

}
