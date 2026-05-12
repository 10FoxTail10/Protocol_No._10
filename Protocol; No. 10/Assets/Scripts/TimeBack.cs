using UnityEngine;

public class TimeBack : MonoBehaviour
{
    public GameObject[] objectsToToggle;  // Массив всех переключаемых объектов
    int activeIndex = 0;                   // Индекс текущего активного объекта
    float activationDuration = 10f;        // Длительность активности второго объекта
    float cooldownPeriod = 5f;             // Период восстановления
    float nextAvailableTime = 0f;          // Время следующего разрешения активации

    void Start()
    {
        // Изначальная активация объекта под индексом 0
        objectsToToggle[activeIndex].SetActive(true);
    }

    void Update()
    {
        // Проверяем, можно ли переключить объект
        if (nextAvailableTime <= Time.time && Input.GetKeyDown(KeyCode.C))
        {
            StartActivationSequence();
        }
    }

    void StartActivationSequence()
    {
        // Переключаем на объект под индексом 1
        SetObjectActive(1);

        // Устанавливаем срок активности
        Invoke(nameof(RestoreDefaultState), activationDuration);

        // Рассчитываем время следующего переключения
        nextAvailableTime = Time.time + activationDuration + cooldownPeriod;
    }

    void RestoreDefaultState()
    {
        // Возвращаем активность объекту под индексом 0
        SetObjectActive(0);
    }

    void SetObjectActive(int index)
    {
        // Отключаем все объекты кроме выбранного
        for (int i = 0; i < objectsToToggle.Length; i++)
        {
            objectsToToggle[i].SetActive(i == index);
        }

        // Сохраняем индекс активного объекта
        activeIndex = index;

        // Сообщаем об изменении
        Debug.Log($"Активированный объект: {objectsToToggle[index].name}");
    }

    void OnEnable()
    {
        // Все объекты предварительно отключаем
        foreach (var obj in objectsToToggle)
        {
            obj.SetActive(false);
        }
    }
}