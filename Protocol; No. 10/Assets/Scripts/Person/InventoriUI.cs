using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoriUI : MonoBehaviour
{
    public ItemController itemController; // Ссылка на логику инвентаря
    public GameObject itemSlotPrefab; // Префаб ячейки, который мы создали
    public Transform contentPanel; // Панель, куда будем добавлять ячейки

    private List<GameObject> currentSlots = new List<GameObject>(); // Список созданных ячеек

    void OnEnable()
    {
        // Подписываемся на событие изменения инвентаря
        itemController.onInventoryChanged += UpdateUI;
    }

    void OnDisable()
    {
        // Отписываемся, чтобы не было ошибок
        itemController.onInventoryChanged -= UpdateUI;
    }

    void Start()
    {
        // Находим панель для контента (обычно это первый/второй дочерний объект)
        contentPanel = transform.Find("Content") ?? transform;
        UpdateUI();
    }

    // Этот метод будет вызываться при каждом изменении инвентаря
    public void UpdateUI()
    {
        Debug.Log("Обновление UI");

        // 1. Удаляем старые ячейки, если их больше, чем предметов
        if (itemController.inventory.Count < currentSlots.Count)
        {
            for (int i = currentSlots.Count - 1; i >= itemController.inventory.Count; i--)
            {
                Destroy(currentSlots[i]);
            }
            currentSlots.RemoveRange(itemController.inventory.Count, currentSlots.Count - itemController.inventory.Count);
        }

        // 2. Обновляем или создаем новые ячейки
        for (int i = 0; i < itemController.inventory.Count; i++)
        {
            ItemData item = itemController.inventory[i];

            if (i < currentSlots.Count)
            {
                // Ячейка уже существует, просто обновляем текст
                UpdateSlot(currentSlots[i], item);
            }
            else
            {
                // Ячейки нет, создаем новую
                GameObject newSlot = Instantiate(itemSlotPrefab, contentPanel);
                UpdateSlot(newSlot, item);
                currentSlots.Add(newSlot);
            }
        }
    }

    // Вспомогательный метод для обновления одной ячейки
    void UpdateSlot(GameObject slotObject, ItemData item)
    {
        // Находим компоненты текста внутри ячейки
        TextMeshProUGUI nameText = slotObject.transform.Find("ItemNameText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI countText = slotObject.transform.Find("ItemCountText").GetComponent<TextMeshProUGUI>();

        // Если используешь обычный Text, замени TextMeshProUGUI на Text

        if (nameText != null) nameText.text = item.name;

        // Отображаем количество только если оно больше 1 (для стакающихся предметов)
        if (countText != null)
        {
            countText.text = item.quantity > 1 ? item.quantity.ToString() : "";
            countText.gameObject.SetActive(item.quantity > 1);
        }

        // Здесь можно добавить логику смены иконки предмета (Image.sprite), если она есть в ItemData
    }
}
