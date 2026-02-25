using using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Random_Text : MonoBehaviour
{
    private List<string> texts = new List<string>();
    public TMP_Text text;

    void Start()
    {
        texts.Add("1) Привет");
        texts.Add("2) Мир");
        texts.Add("3) Хочу пиццы");
        texts.Add("4) Давай заходи)");
        texts.Add("5) Время не циклично");
        texts.Add("6) Следи за своими действиями");
        texts.Add("7) Можно денежку?");
        texts.Add("8) Я стану Королём, а может Пешкой");
        texts.Add("*) Надо спать, не надо напрягаться");
        texts.Add("((Хочу сделать виликую игру, помогите(");
        texts.Add("0)Добавлять текст не сложно...");
        texts.Add("12_...сложно его придумывать");
        texts.Add("13) C# и Unity это класная тема");
        texts.Add("14) А ещё Blender");
        texts.Add("20) Я не хочу быть сварщиком, но видимо придёться(");
        texts.Add("Возможно я в одном пункте допустил ошибку)");
        texts.Add("10foxtail10@gmail.com Почта для связи со мной, если не нашли)");

        int randomIndex = Random.Range(0, texts.Count);

        text.text = texts[randomIndex];
    }
}
