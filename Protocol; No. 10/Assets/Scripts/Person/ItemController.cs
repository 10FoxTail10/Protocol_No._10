using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; // Нужно для OrderBy
using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с глобальными переменными
    [SerializeField] private PickupItem _pickupItem; // Скрипт с настройками предмета

    [SerializeField] public List<ItemData> inventory = new List<ItemData>(); // Список предметов в инвентаре
    [SerializeField] public event Action onInventoryChanged;
    [SerializeField] private string _savePath;

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitItem;

    void Awake()
    {
        _savePath = Path.Combine(Application.persistentDataPath, "saving.json"); // Путь к файлу сохранения. Он будет в скрытой папке пользователя.

        LoadInventory();
        //Debug.Log("Инвентарь загружен. Путь: " + _savePath);
    }

    void Start()
    {
        _tips = _globalSetting.tips;
    }

    void Update()
    {
        _hitItem = _pressE._hit;

        // Очистка всего инвентаря (Черная дыра Тестовая фигня)
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.Clear();
            onInventoryChanged?.Invoke();
            SaveInventory();
            Debug.Log("Инвентарь очищен!");
        }
    }

    private bool IsStackableItem(bool itemStack)
    {
        if (itemStack == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddItem(ItemData newItem)
    {
        // 1. Проверяем, можно ли стакать этот предмет
        if (IsStackableItem(newItem.isStackble))
        {
            // 2. Ищем уже существующий стак этого предмета в инвентаре
            ItemData existingStack = inventory.FirstOrDefault(item => item.id == newItem.id);

            if (existingStack != null)
            {
                //    // 3. Если нашли, увеличиваем количество (здесь можно добавить проверку на лимит 8)
                existingStack.quantity += newItem.quantity;
                Debug.Log($"Стакнули {newItem.name}. Всего: {existingStack.quantity} шт.");
            }
            else
            {
                // 4. Если стака нет, просто добавляем новый слот
                inventory.Add(newItem);
                Debug.Log($"Создан новый стак для {newItem.name}: {newItem.quantity} шт.");
            }
        }
        else
        {
            ItemData existingStack = inventory.FirstOrDefault(item => item.id == newItem.id);
            if (existingStack != null)
            {
                Debug.Log($"Уже есть: {newItem.name}");
                return;
            }
            else
            {
                inventory.Add(newItem);
                Debug.Log($"Добавлен новый предмет: {newItem.name}");
                Debug.Log($"ID: {newItem.id} \nПодобрано: {newItem.name} x{newItem.quantity} \nОписание предмета: {newItem.description} \nСтаты: {newItem.stats}");

            }
        }

        onInventoryChanged?.Invoke();
        SaveInventory();
    }

    //// Удаление предмета по ID
    //public void RemoveItem(string itemId)
    //{
    //    inventory.RemoveAll(i => i.id == itemId);
    //    onInventoryChanged?.Invoke();
    //    SaveInventory();
    //    Debug.Log("Удален предмет с ID: " + itemId);
    //}


    // Сохранение в JSON

    private void SaveInventory()
    {
        string json = JsonUtility.ToJson(new InventoryContainer { items = inventory }, true); // true для красивого вида
        File.WriteAllText(_savePath, json);
    }

    // Загрузка из JSON
    private void LoadInventory()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            InventoryContainer container = JsonUtility.FromJson<InventoryContainer>(json);
            inventory = container.items;
            Debug.Log("Загружено " + inventory.Count + " предметов.");
        }
        else
        {
            Debug.Log("Файл сохранения не найден. Создадим новый.");
            inventory = new List<ItemData>();
            SaveInventory(); // Создаем пустой файл при первом запуске
        }
    }
}

// Вспомогательный класс-контейнер для JSON (JsonUtility требует корневой объект)
[System.Serializable]
public class InventoryContainer
{
    public List<ItemData> items;
}
