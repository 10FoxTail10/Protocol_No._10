using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitInMenu : MonoBehaviour
{
    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
