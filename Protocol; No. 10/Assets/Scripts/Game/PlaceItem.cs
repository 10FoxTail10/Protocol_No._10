using UnityEngine;
using TMPro;

public class PlaceItem : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с переменными
    [SerializeField] public ItemController itemController;

    [Header("Item")]
    [SerializeField] private string _itemID;
    [SerializeField] public GameObject obj;
    [SerializeField] public bool isActive;
    [SerializeField] public Collider collider;
    [SerializeField] public Collider triger_col;

    [Header("Private")]
    private TMP_Text _tips;
    [SerializeField] private RaycastHit _hitItem;

    void Start()
    {
        _tips = _globalSetting.tips;
        collider.isTrigger = true;
        triger_col.enabled = true;
    }

    public void PlaceItemWord()
    {
        if (!isActive)
        {
            _hitItem = _pressE._hit;
            _tips.text = "Нажмите 'E', чтобы положить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Place();
                isActive = true;
            }
        }
        else
        {
            _tips.text = "";
        }
    }

    private void Place()
    {
        collider.isTrigger = false;
        triger_col.enabled = false;
        obj.SetActive(true);
    }

    //private void CollectItem()
    //{

    //    AudioSource.PlayClipAtPoint(soundSelection, transform.position);
    //    _tips.text = "";

    //    // --- СОЗДАНИЕ ПРЕДМЕТА ---
    //    ItemData newItem = new ItemData
    //    {
    //        id = itemID,
    //        name = itemName,
    //        description = itemDescription,
    //        isStackble = itemIsStackble,
    //        quantity = itemQuantity,
    //        stats = statsItem,
    //        x = -1, // -1 означает, что предмет не на сетке, а просто в "рюкзаке" (инвентарь)
    //        y = -1  // Или координаты слота быстрого доступа
    //    };

    //    itemController.AddItem(newItem);

    //    Destroy(_hitItem.collider.gameObject);

    //    // --- ЛОГИКА ЛИМИТА ---
    //    // Находим текущий стак этого зелья в инвентаре (если он есть)
    //    ItemData currentStack = itemController.inventory.Find(i => i.id == itemID);
    //    int currentAmount = currentStack != null ? currentStack.quantity : 0;

    //    // Считаем свободное место до лимита (8)
    //    int freeSpace = 8 - currentAmount;

    //    if (freeSpace <= 0)
    //    {
    //        Debug.Log("Инвентарь полон! Места для зелий нет.");
    //        return; // Не подбираем ничего, если места нет совсем
    //    }

    //    // Сколько мы МОЖЕМ забрать, чтобы не превысить лимит?
    //    int quantityToAdd = Mathf.Min(1, freeSpace);

    //    if (quantityToAdd < 1)
    //    {
    //        Debug.Log($"Мешок полон! Подобрано только {quantityToAdd} из {1} шт.");
    //    }
    //}
}
