using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public float delay = 0.1f; // Задержка между символами
    private string fullText;
    private int currentIndex = 0;
    private bool isRunning = false;

    void Start()
    {
        if (!GetComponent<TextMeshProUGUI>())
            Debug.LogError("Требуется компонент TextMeshProUGUI");

        fullText = GetComponent<TextMeshProUGUI>().text;
        GetComponent<TextMeshProUGUI>().text = "";
        isRunning = true;
        InvokeRepeating(nameof(TypeNextCharacter), 0f, delay);
    }

    void TypeNextCharacter()
    {
        if (currentIndex >= fullText.Length)
        {
            CancelInvoke();
            return;
        }

        GetComponent<TextMeshProUGUI>().text += fullText[currentIndex++];
    }
}
