using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_In_Menu : MonoBehaviour
{
    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
