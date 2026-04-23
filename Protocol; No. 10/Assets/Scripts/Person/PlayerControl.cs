using UnityEngine;
using System.Collections.Generic;

// работает через Rigidbody, для прыжка нужна поверхность с маской, а у персонажа в самой нижней части пустышка

public class PlayerControl : MonoBehaviour
{
    #region Variables
    [Header("Camera")]
    [SerializeField] public Transform _head;
    [SerializeField] public float _sensetivity = 2f;

    private float xRot = 0f;
    private float _maxAng = 80f;
    private float _minAng = -60f;

    [Header("Move")]
    [SerializeField] public float speed;
    [SerializeField] public float speedX; // Множитель скорости персонажа
    [SerializeField] public float jumpSpeed;
    [SerializeField] public Rigidbody rb;

    private float _horizontal;
    private float _vertical;
    private float _speed;
    private Vector3 _move;

    [Header("Jump")]
    [SerializeField] public Transform feetTransform;
    [SerializeField] public LayerMask floorMask;
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _speed = speed;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Run();
        Jump();
        Rotate();
    }

    public void Move()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _move = new Vector3(_horizontal, 0f, _vertical);

        Vector3 MoveVec = transform.TransformDirection(_move) * speed;
        rb.linearVelocity = new Vector3(MoveVec.x, rb.linearVelocity.y, MoveVec.z);
    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && speed < _speed * speedX)
        {
            speed *= speedX;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = _speed;
        }
    }
    
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Physics.CheckSphere(feetTransform.position, 0.1f, floorMask))
            {
                rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        }
    }

    private void Rotate()
    {
        float rotationY = Input.GetAxis("Mouse X") * _sensetivity; //(крутим мышкой влево-вправо)
        float rotationX = Input.GetAxis("Mouse Y") * _sensetivity; //(крутим мышкой вверх-вниз)

        xRot -= rotationX;
        xRot = Mathf.Clamp(xRot, _minAng, _maxAng); // Огранка по повороту камеры в вертикаль

        Quaternion yRotation = Quaternion.AngleAxis(rotationY, Vector3.up);           // Горизонт
        Quaternion xRotation = Quaternion.AngleAxis(xRot, Vector3.right);          // Вертикаль

        transform.rotation *= yRotation;
        _head.localRotation = xRotation;
    }
}
