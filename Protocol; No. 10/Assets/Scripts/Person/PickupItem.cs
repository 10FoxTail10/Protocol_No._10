using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// И так, тут у нас просто перепись предмета и его взаимодействие (только одного, на который наложен скрипт. Используется совместно с скриптом ItemData)

public class PickupItem : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с переменными
    [SerializeField] public ItemController itemController;

    [Header("Item")]
    [SerializeField] public AudioClip soundSelection; // Звуковой эффект подбора предмета
    private ItemData _itemData; // Скрипт с настройками предмета

    [Header("Item ID")]
    [SerializeField] public string itemID; // Уникальный ID типа (например: "potion_health")

    [Header("Item")]
    [SerializeField] public string itemName;
    [SerializeField] public string itemDescription; // Описание
    [SerializeField] public bool itemIsStackble; // Можно ли стакать предметы
    [Range(1, 15)] public int itemQuantity = 1; // Количество предметов в этом слоте (Если пули в коробке или что-то подобное, иначе 1)
    [SerializeField] public List<StatPair> statsItem = new List<StatPair>(); // Статы для оружия или особых расходников


    [Header("Private")]
    private TMP_Text _tips;
    [SerializeField] private RaycastHit _hitItem;

    void Start()
    {
        _tips = _globalSetting.tips;
    }

    public void SelectionItem()
    {
        _hitItem = _pressE._hit;
        _tips.text = "Нажмите 'E', чтобы подобрать";
        if (Input.GetKeyDown(KeyCode.E))
        {
            CollectItem();
        }
    }

    private void CollectItem()
    {
        
        AudioSource.PlayClipAtPoint(soundSelection, transform.position);
        _tips.text = "";

        // --- СОЗДАНИЕ ПРЕДМЕТА ---
        ItemData newItem = new ItemData
        {
            id = itemID,
            name = itemName,
            description = itemDescription,
            isStackble = itemIsStackble,
            quantity = itemQuantity,
            stats = statsItem,
            x = -1, // -1 означает, что предмет не на сетке, а просто в "рюкзаке" (инвентарь)
            y = -1  // Или координаты слота быстрого доступа
        };

        itemController.AddItem(newItem);

        Destroy(_hitItem.collider.gameObject);

        //// --- ЛОГИКА ЛИМИТА ---
        //// Находим текущий стак этого зелья в инвентаре (если он есть)
        //ItemData currentStack = itemController.inventory.Find(i => i.id == itemId);
        //int currentAmount = currentStack != null ? currentStack.quantity : 0;

        //// Считаем свободное место до лимита (8)
        //int freeSpace = 8 - currentAmount;

        //if (freeSpace <= 0)
        //{
        //    Debug.Log("Инвентарь полон! Места для зелий нет.");
        //    return; // Не подбираем ничего, если места нет совсем
        //}

        //// Сколько мы МОЖЕМ забрать, чтобы не превысить лимит?
        //int quantityToAdd = Mathf.Min(dropQuantity, freeSpace);

        //if (quantityToAdd < dropQuantity)
        //{
        //    Debug.Log($"Мешок полон! Подобрано только {quantityToAdd} из {dropQuantity} шт.");
        //}



    }

}
