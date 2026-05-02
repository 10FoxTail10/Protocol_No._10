using UnityEngine;
using TMPro;

// И так, тут у нас прорсто перепись предмета (только одного, на который наложен скрипт, используется только со скриптом ItemData)

public class PickupItem : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] public AudioClip soundSelection; // Звуковой эффект подбора предмета

    [Header("Private")]
    private ItemData _itemData; // Скрипт с настройками предмета
    private TMP_Text _tips;
    private RaycastHit _hitItem;

    void Start()
    {
        _tips = _globalSetting.tips;
        _hitItem = _pressE._hit;
    }

    public void SelectionItem()
    {
        _itemData = _hitItem.collider.GetComponent<ItemData>();
        _tips.text = "Нажмите 'E', чтобы подобрать";
        if (Input.GetKeyDown(KeyCode.E))
        {
            CollectWatch();
        }
    }

    private void CollectWatch()
    {
        Destroy(_hitItem.collider.gameObject);
        AudioSource.PlayClipAtPoint(soundSelection, transform.position);
        _tips.text = "";
    }

}
