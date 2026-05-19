using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Нужно для OrderBy
using TMPro;
using UnityEngine;

public class Play : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] public ItemController itemController; // Ссылка на логику инвентаря
    public void PlayGame()
    {
        StartCoroutine(LoadSceneWithDelay());
    }

    IEnumerator LoadSceneWithDelay()
    {
        // Задержка на 2 секунды
        yield return new WaitForSeconds(2f);

        // Загрузка сцены
        SceneManager.LoadScene(1);
        itemController.RemoveItem();
    }
}
