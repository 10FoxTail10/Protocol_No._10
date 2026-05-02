using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using TMPro;

[System.Serializable]
public struct ButtonState
{
    public string hoverText;    // Текст при наведении
}

public class MenuText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Menu")]
    [SerializeField] public TMP_Text textComponent;    // Компонент текста для вывода подсказки
    [SerializeField] public string startText;   // Стартовый текст кнопки (должен иметь запись из рандомайзеа фраз)
    [SerializeField] public ButtonState state;    // Сохранения состояния текста

    [Header("Private")]
    [SerializeField] private string _initialText;    // Сохраняет оригинальный текст кнопки

    private void Start()
    {
        textComponent.text = startText;
    }

    void Awake()
    {
        if (textComponent != null)
        {
            _initialText = textComponent.text;   // Запоминаем стартовый текст
            startText = _initialText;     // Устанавливаем нормальный текст
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (textComponent != null && !string.IsNullOrEmpty(state.hoverText))
        {
            textComponent.text = state.hoverText; // Показываем текст при наведении
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (textComponent != null)
            textComponent.text = startText; // Восстанавливаем текст
    }
}