using UnityEngine;
using TMPro;

public class GlobalSet : MonoBehaviour
{
    #region Game_Setting
    [Header("Game Setting")]
    [SerializeField] public float globalVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))
    [SerializeField] public float musicVolume = 1f;
    [SerializeField] public float effectVolume = 1f;
    [SerializeField]

    #endregion

    #region Player_Setting
    [Header("Player Setting")]
    [SerializeField] public TMP_Text tip;   // UI текст, куда выводится подсказка
    [SerializeField] public bool isInRange = false; // Флаг близости к объекту
    [SerializeField]
    [SerializeField]

    #endregion

    public int assss = 15;

    void Update()
    {
        Debug.Log(assss);
    }

    //#region HotKey_Setting

    //#endregion

    void Start()
    {
        tip.text = ""; // Базовое значение подсказки для игрока в начале игры
        audioTV.volume = startVolume; // Изменение на базовое значение звука
    }
}
