using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Нужно для OrderBy
using TMPro;
using UnityEngine;

public class TimeBack : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с глобальными переменными
    [SerializeField] private ItemController _itemController; // Скрипт с глобальными переменными

    public GameObject[] objectsToToggle;  // Массив всех переключаемых объектов
    int activeIndex = 0;                   // Индекс текущего активного объекта
    public float activationDuration = 1f;        // Длительность активности второго объекта
    float cooldownPeriod = 1f;             // Период восстановления
    float nextAvailableTime = 0f;          // Время следующего разрешения активации

    private bool _hasAppliedCristal = false;
    private bool _hasAppliedGear = false;


    void Start()
    {
        objectsToToggle[activeIndex].SetActive(true);
    }

    void Update()
    {
        // Проверяем, можно ли переключить объект
        if (nextAvailableTime <= Time.time && Input.GetKeyDown(KeyCode.C))
        {
            StartActivationSequence();
        }


        UseItemStat("Gear_Stabilizer", "Time_Back_Gear");
        UseItemStat("Cristal_Stabilizer", "Time_Back_Cristal");
    }

    void StartActivationSequence()
    {
        // Переключаем на объект под индексом 1
        SetObjectActive(1);

        // Устанавливаем срок активности
        Invoke(nameof(RestoreDefaultState), activationDuration);

        // Рассчитываем время следующего переключения
        nextAvailableTime = Time.time + activationDuration + cooldownPeriod;
    }

    void RestoreDefaultState()
    {
        // Возвращаем активность объекту под индексом 0
        SetObjectActive(0);
    }

    void SetObjectActive(int index)
    {
        // Отключаем все объекты кроме выбранного
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(i == index);
        }

        // Сохраняем индекс активного объекта
        activeIndex = index;

        // Сообщаем об изменении
        Debug.Log($"Активированный объект: {objectsToToggle[index].name}");
    }

    void OnEnable()
    {
        // Все объекты предварительно отключаем
        foreach (var obj in objectsToToggle)
        {
            obj.SetActive(false);
        }
    }

    void UseItemStat(string itemId, string statKey)
    {
        int statValue = _itemController.GetItemStat(itemId, statKey);

        if (statValue != 0)
        {
            Debug.Log($"У предмета {itemId} стат {statKey} = {statValue}");
            PlayTime(statKey, statValue);
        }
        else
        {
            Debug.Log($"Предмет {itemId} не найден или у него нет стата {statKey}");
        }
    }

    public void PlayTime(string statKey, float statValue)
    {
        switch (statKey)
        {
            case "Time_Back_Cristal":
                ApplyTimeCristal(statValue);
                break;
            case "Time_Back_Gear":
                ApplyTimeGear(statValue);
                break;
        }
    }

    private void ApplyTimeCristal(float value)
    {
        if (_hasAppliedCristal)
            return;
        activationDuration += value;
        Debug.Log(value);
        Debug.Log(activationDuration);
        _hasAppliedCristal = true;
    }

    private void ApplyTimeGear(float value)
    {
        if (_hasAppliedGear)
            return;
        activationDuration += value;
        Debug.Log(value);
        Debug.Log(activationDuration);
        _hasAppliedGear = true;
    }

}