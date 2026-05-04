using UnityEngine;
using TMPro;

public class MechanismController : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSetting _globalSetting; // Скрипт с глобальными переменными
    [SerializeField] private PressE _pressE;

    [Header("Mechanism")]
    [SerializeField] private bool _mechanismIsStatus; // Статус механизмов (вкл/выкл)
    [SerializeField] private bool _lockIsStatus; // Статус блокировки (Можно ли повторно использовать механизм)

    [Header("Private")]
    private TMP_Text _tips;
    private RaycastHit _hitMechanism;

    void Start()
    {
        _tips = _globalSetting.tips;
    }

    public void ChangeActiveMechanism()
    {
        _hitMechanism = _pressE._hit;
        if (!_mechanismIsStatus)
        {
            _tips.text = "Нажмите 'E', чтобы включить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                _pressE.TurnOnTV();
                _mechanismIsStatus = true;
            }
        }
        else if (_mechanismIsStatus && !_lockIsStatus)
        {
            _tips.text = "Нажмите 'E', чтобы выключить";
            if (Input.GetKeyDown(KeyCode.E))
            {
                _pressE.TurnOffTV();
                _mechanismIsStatus = false;
            }
        }
    }

}
