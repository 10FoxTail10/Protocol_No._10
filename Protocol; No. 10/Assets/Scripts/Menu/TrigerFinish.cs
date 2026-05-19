using UnityEngine;
using UnityEngine.SceneManagement;

public class TrigerFinish : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
