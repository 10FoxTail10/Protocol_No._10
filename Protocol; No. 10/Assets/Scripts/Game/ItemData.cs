using UnityEngine;
using System.Collections.Generic;

// Люблю делать описания для себя)
// Здесь всё для того, чтобы можно было сохранить и иметь предмет в инвентаре
// В основном это полезные предметы для квестов, или обычные расходники, или оружие

[System.Serializable]
public class ItemData
{
    [Header("Item")]
    [SerializeField] public string id; // Уникальный ID типа (например: "potion_health")
    [SerializeField] public string name;
    [SerializeField] public string description; // Описание предмета
    [SerializeField] public bool isStackable; // Можно ли стакать предметы
    [SerializeField] public int x, y; // Позиция в инвентаре
    [SerializeField] public int quantity = 1; // Количество предметов в этом слоте (Если пули в коробке или что-то подобное, иначе 1)
    // Статы оставляем для оружия и брони
    [SerializeField] public List<StatPair> stats = new List<StatPair>();

}

[System.Serializable]
public class StatPair
{
    public string key;
    public int value;
}
