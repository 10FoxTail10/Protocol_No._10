using System;
using System.IO;
using System.Linq; // Нужно для OrderBy
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с глобальными переменными
    [SerializeField] private PickupItem _pickupItem; // Скрипт с настройками предмета

    [SerializeField] public bool isStack

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
        Debug.Log("Инвентарь загружен. Путь: " + _savePath);
    }

    void Start()
    {
        _tips = _globalSetting.tips;

    }

    void Update()
    {
        _hitItem = _pressE._hit;
    }

    // Определяем, какие предметы могут стакаться.
    // Для простоты проверяем по ID. В сложной игре лучше добавить в ItemData поле bool isStackable.
    private bool IsStackableItem(string itemId)
    {
        return itemId.StartsWith("potion"); // Все, что начинается на "potion", будет стакаться
    }

    public void AddItem(ItemData newItem)
    {
        // 1. Проверяем, можно ли стакать этот предмет
        if (IsStackableItem(newItem.id))
        {
            // 2. Ищем уже существующий стак этого предмета в инвентаре
            ItemData existingStack = inventory.FirstOrDefault(item => item.id == newItem.id);

            if (existingStack != null)
            {
                // 3. Если нашли, увеличиваем количество (здесь можно добавить проверку на лимит 8)
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
            // Если предмет не стакабельный (меч, броня), добавляем как новый уникальный предмет
            inventory.Add(newItem);
            Debug.Log($"Добавлен уникальный предмет: {newItem.name}");
        }

        onInventoryChanged?.Invoke();
        SaveInventory();
    }

    // Удаление предмета по ID
    public void RemoveItem(string itemId)
    {
        inventory.RemoveAll(i => i.id == itemId);
        onInventoryChanged?.Invoke();
        SaveInventory();
        Debug.Log("Удален предмет с ID: " + itemId);
    }

    // Очистка всего инвентаря (Черная дыра)
    public void ClearInventory()
    {
        inventory.Clear();
        onInventoryChanged?.Invoke();
        SaveInventory();
        Debug.Log("Инвентарь очищен!");
    }

    // Удаление случайных предметов (Сундук потерь)
    public void RemoveRandomItems(float percent)
    {
        // 1. Считаем общее количество всех предметов в инвентаре (суммируем quantity)
        int totalQuantity = inventory.Sum(item => item.quantity);

        if (totalQuantity <= 0) return;

        // 2. Вычисляем, сколько штук нужно удалить
        int totalToRemove = Mathf.RoundToInt(totalQuantity * percent);
        Debug.Log($"Сундук хочет забрать {totalToRemove} шт. из {totalQuantity} доступных.");

        // Создаем копию списка для работы, чтобы не менять оригинал во время итерации
        List<ItemData> itemsPool = new List<ItemData>(inventory);
        System.Random rnd = new System.Random();

        // 3. Пока нам еще есть что удалять
        while (totalToRemove > 0 && itemsPool.Count > 0)
        {
            // Выбираем случайный предмет из оставшихся
            ItemData targetItem = itemsPool.OrderBy(x => rnd.Next()).First();

            // Сколько мы можем забрать из этого конкретного слота?
            // Берем либо всё, что осталось в стеке, либо столько, сколько нам еще нужно до лимита.
            int amountToTake = Mathf.Min(targetItem.quantity, totalToRemove);

            // Уменьшаем количество в слоте
            targetItem.quantity -= amountToTake;
            totalToRemove -= amountToTake;

            Debug.Log($"Забрано {amountToTake} шт. из слота '{targetItem.name}'. Осталось забрать: {totalToRemove}");

            // Если в слоте закончились предметы, удаляем его из пула и из основного инвентаря
            if (targetItem.quantity <= 0)
            {
                inventory.Remove(targetItem);
                itemsPool.Remove(targetItem);
            }
        }

        onInventoryChanged?.Invoke();
        SaveInventory();
    }

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
