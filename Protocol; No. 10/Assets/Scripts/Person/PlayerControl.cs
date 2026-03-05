using UnityEngine;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    [Header("Rotate")]
    [SerializeField] public float speed = 1f;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public Transform _head;
    
    private float _horizontal;
    private float _vertical;
    private float _sensetivity = 2f; // Настройки чувствительности

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        Rotate();
    }


    public void Move()
    {
        _horizontal =  Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        rb.AddForce(((transform.right * _horizontal) + (transform.forward * _vertical)) * speed);
        
        /*bool forward = Input.GetKey(KeyCode.W);
        bool back = Input.GetKey(KeyCode.S);
        bool right = Input.GetKey(KeyCode.D);
        bool left = Input.GetKey(KeyCode.A);
        bool rightDiag = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D);
        bool leftDiag = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A);
        bool rightDiagBack = Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D);
        bool leftDiagBack = Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A);
        if (rightDiag)
        {
            transform.position += transform.forward * Time.deltaTime * speed + transform.right * Time.deltaTime * speed;
        }
        else if (leftDiag)
        {
            transform.position += transform.forward * Time.deltaTime * speed + -transform.right * Time.deltaTime * speed;
        }
        else if (rightDiagBack)
        {
            transform.position += -transform.forward * Time.deltaTime * speed + transform.right * Time.deltaTime * speed;
        }
        else if (leftDiagBack)
        {
            transform.position += -transform.forward * Time.deltaTime * speed + -transform.right * Time.deltaTime * speed;
        }
        else if (forward)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if (back)
        {
            transform.position += -transform.forward * Time.deltaTime * speed;
        }
        else if (right)
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }
        else if (left)
        {
            transform.position += -transform.right * Time.deltaTime * speed;
        }*/
    }

    private void Rotate()
    {
        float rotationY = Input.GetAxis("Mouse X") * _sensetivity;
        float rotationX = Input.GetAxis("Mouse Y") * _sensetivity;
        transform.Rotate(0, rotationY, 0);
        _head.Rotate(-rotationX, 0, 0);
    }
}
