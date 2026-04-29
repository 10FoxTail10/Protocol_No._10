using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ExitDoorController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSet _globalSet; // Скрипт с глобальными переменными
    [SerializeField] private Press_E _press_E; // Скрипт с глобальными переменными

    [Header("Door")]
    [SerializeField] public AudioClip soundDoor; // Звуковой эффект двери

    [Header("Next Level")]
    [SerializeField] private int _sceneIndex;

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitDoor;

    void Start()
    {
        _tips = _globalSet.tips;
        _hitDoor = _press_E._hit;
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Номер сцены" + _sceneIndex);
    }

    public void NextLV()
    {
        _tips.text = "Нажмите 'E', чтобы выйти";
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(_sceneIndex + 1);
        }
    }

}
