using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// Компонент для хранения состояний текста кнопки
[System.Serializable]
public struct ButtonState
{
    public string normalText;     // Обычный текст кнопки
    public string hoverText;      // Текст при наведении
}

public class Menu_Text : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text textComponent;       // Привязываем компонент текста
    public ButtonState state;        // Структура для хранения состояния текста

    private string initialText;      // Сохраняет оригинальный текст кнопки

    void Awake()
    {
        if (textComponent != null)
        {
            initialText = textComponent.text;   // Запоминаем изначальный текст
            state.normalText = initialText;     // Устанавливаем нормальный текст
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textComponent != null && !string.IsNullOrEmpty(state.hoverText))
            textComponent.text = state.hoverText; // Показываем текст при наведении
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (textComponent != null)
            textComponent.text = state.normalText; // Восстанавливаем обычный текст
    }
}