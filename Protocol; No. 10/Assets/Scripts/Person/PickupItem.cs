using UnityEngine;
using TMPro;

public class PickupItem : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с глобальными переменными
    [SerializeField] private ItemData _itemData; // Скрипт с настройками предмета

    [Header("Item")]
    [SerializeField] public AudioClip soundSelection; // Звуковой эффект подбора предмета

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitItem;

    void Start()
    {
        _tips = _globalSetting.tips;
        _hitItem = _pressE._hit;
        _itemData = _hitItem.collider.GetComponent<ItemData>();
    }

    public void SelectionItem()
    {
        if (true)
        {
            _tips.text = "Нажмите 'E', чтобы подобрать";
            if (Input.GetKeyDown(KeyCode.E))
            {
                CollectWatch();
            }
        }
    }

    private void CollectWatch()
    {
        Destroy(_hitItem.collider.gameObject);
        AudioSource.PlayClipAtPoint(soundSelection, transform.position);
        _tips.text = "";
    }

}
