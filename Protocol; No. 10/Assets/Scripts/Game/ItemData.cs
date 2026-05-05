using UnityEngine;
using System.Collections.Generic;

// Люблю делать описания для себя)
// Здесь всё для того, чтобы можно было сохранить и иметь предмет в инвентаре
// В основном это полезные предметы для квестов, или обычные расходники, или оружие

[System.Serializable]
public class ItemData
{
    [Header("Item ID")]
    [SerializeField] public string id; // Уникальный ID типа (например: "potion_health")

    [Header("Item")]
    [SerializeField] public string name;
    [SerializeField] public string description; // Описание
    [SerializeField] public bool isStackble; // Можно ли стакать предметы
    [Range(1, 15)] public int quantity = 1; // Количество предметов в этом слоте (Если пули в коробке или что-то подобное, иначе 1)
    [SerializeField] public List<StatPair> stats = new List<StatPair>(); // Статы для оружия или особых расходников

    [Header("Inventory position")]
    [SerializeField] public int x, y; // Позиция в инвентаре
    
}

[System.Serializable]
public class StatPair
{
    public string key;
    public int value;
}
