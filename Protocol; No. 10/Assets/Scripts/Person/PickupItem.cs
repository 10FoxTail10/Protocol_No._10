using UnityEngine;
using TMPro;

// И так, тут у нас просто перепись предмета и его взаимодействие (только одного, на который наложен скрипт. Используется только со скриптом ItemData)

public class PickupItem : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE; // Скрипт с глобальными переменными

    [Header("Item")]
    [SerializeField] public AudioClip soundSelection; // Звуковой эффект подбора предмета
    [SerializeField] private ItemData _itemData; // Скрипт с настройками предмета

    [Header("Private")]
    private TMP_Text _tips;

    void Start()
    {
        _tips = _globalSetting.tips;
    }

    public void SelectionItem()
    {
        _tips.text = "Нажмите 'E', чтобы подобрать";
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    CollectWatch();
        //}
    }

    //private void CollectWatch()
    //{
    //    Destroy(_hitItem.collider.gameObject);
    //    AudioSource.PlayClipAtPoint(soundSelection, transform.position);
    //    _tips.text = "";
    //}

}
