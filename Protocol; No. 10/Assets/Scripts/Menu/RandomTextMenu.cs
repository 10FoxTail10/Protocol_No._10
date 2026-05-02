using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class RandomTextMenu : MonoBehaviour
{
    [Header("Random text")]
    [SerializeField] public List<MenuText> menuText;

    [Header("Private")]
    [SerializeField] private List<string> texts = new List<string>();

    void Start()
    {
        texts.Add("Привет");
        texts.Add("Мир");
        texts.Add("Хочу пиццы");
        texts.Add("Давай заходи)");
        texts.Add("Время не циклично");
        texts.Add("Следи за своими действиями!");
        texts.Add("Можно денежку?");
        texts.Add("Я стану Королём, а может Пешкой");
        texts.Add("Надо спать, не надо напрягаться");
        texts.Add("Хочу сделать отличную игру, помогите(");
        texts.Add("Добавлять текст не сложно...");
        texts.Add("...сложно его придумывать");
        texts.Add("C# и Unity это классная тема");
        texts.Add("А ещё Blender");
        texts.Add("№10");
        texts.Add("Я не хочу быть сварщиком, но видимо так тому и быть(");
        texts.Add("Возможно я в одном пункте допустил ошибку)");
        texts.Add("10foxtail10@gmail.com Почта для связи со мной, если не нашли)");

        int rndIndex = Random.Range(0, texts.Count);

        for (int i = 0; i < menuText.Count; i++)
        {
            menuText[i].startText = texts[rndIndex];
        }
    }
}