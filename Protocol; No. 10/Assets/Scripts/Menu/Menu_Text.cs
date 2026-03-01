using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Serialization;


[System.Serializable]
public struct ButtonState
{
    public string hoverText;      // Текст при наведении
}

public class Menu_Text : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text textComponent;       // Привязываем компонент текста
    public string startText;     // Обычный текст кнопки
    public ButtonState state;        // Структура для хранения состояния текст
    private string initialText;      // Сохраняет оригинальный текст кнопки

    private void Start()
    {
        textComponent.text = startText;
    }

    void Awake()
    {
        if (textComponent != null)
        {
            initialText = textComponent.text;   // Запоминаем изначальный текст
            startText = initialText;     // Устанавливаем нормальный текст
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
            textComponent.text = startText; // Восстанавливаем обычный текст
    }
}