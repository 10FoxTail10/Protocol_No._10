using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CameraControl : MonoBehaviour
{
    [Header("Scripts")] // Другие скрипты
    [SerializeField] private GlobalSet _globalSet; // Скрипт с глобальными переменными

    [Header("Camera")]
    [SerializeField] public Transform head;
    [SerializeField] public float sensetivity = 2f;

    [Header("Seat")]
    [SerializeField] private GameObject _person;
    [SerializeField] private Transform _personBody;
    [SerializeField] private GameObject _seatPerson;

    private TMP_Text _tips;
    private float _xRot = 180f;
    private float _maxAng = 80f;
    private float _minAng = -60f;

    void Start()
    {
        _tips = _globalSet.tips;
    }

    void Update()
    {
        Rotate();
        Seat();
    }

    private void Rotate()
    {
        float rotationY = Input.GetAxis("Mouse X") * sensetivity; //(крутим мышкой влево-вправо)
        float rotationX = Input.GetAxis("Mouse Y") * sensetivity; //(крутим мышкой вверх-вниз)

        _xRot -= rotationX;
        _xRot = Mathf.Clamp(_xRot, _minAng, _maxAng); // Огранка по повороту камеры в вертикаль

        Quaternion yRotation = Quaternion.AngleAxis(rotationY, Vector3.up);           // Горизонт
        Quaternion xRotation = Quaternion.AngleAxis(_xRot, Vector3.right);          // Вертикаль

        transform.rotation *= yRotation;
        head.localRotation = xRotation;
    }

    private void Seat()
    {
        _tips.text = "Нажмите 'Q', чтобы встать";
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _personBody.transform.Rotate(0, 180, 0);
            _person.SetActive(true);
            _seatPerson.SetActive(false);
        }
    }

}
