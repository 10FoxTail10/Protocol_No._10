using UnityEngine;
using TMPro;

public class GlobalSet : MonoBehaviour
{
    #region Game_Setting
    [Header("Game Setting")]
    [SerializeField] public float globalVolume = 1f; // Базовое значение звука в игре (Значение от 0 (без звука) до 1 (полная громкость))
    [SerializeField] public float musicVolume = 1f;
    [SerializeField] public float effectVolume = 1f;

    #endregion

    #region Player_Setting
    [Header("Player Setting")]
    [SerializeField] public float sensetivity;
    [SerializeField] public bool isInRange = false; // Флаг близости к объекту

    #endregion

    public int assss = 15;

    void Update()
    {
    }

    //#region HotKey_Setting

    //#endregion

    void Start()
    {
    }
}
