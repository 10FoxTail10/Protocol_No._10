using UnityEngine;
using TMPro;

public class GlobalSetting : MonoBehaviour
{
    #region Game Setting
    [Header("Game Setting")]
    [SerializeField] public float globalVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))
    [SerializeField] public float musicVolume = 1f;
    [SerializeField] public float effectVolume = 1f;

    #endregion

    #region Player Setting
    [Header("Player Setting")]
    [SerializeField] public float sensetivity;
    [SerializeField] public bool isInRange = false; // Флаг близости к объекту

    #endregion

    #region Global Variables
    [Header("UI")]
    [SerializeField] public TMP_Text tips;

    #endregion

    #region HotKey Setting

    #endregion

    void Start()
    {
        tips.text = ""; // Базовое значение подсказки для игрока в начале игры
    }

    void Update()
    {

    }

}
