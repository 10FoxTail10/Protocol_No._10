using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Play : MonoBehaviour
{
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
    }
}
