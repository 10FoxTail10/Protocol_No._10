using UnityEngine;
using System.Collections.Generic;

public class movement : MonoBehaviour
{
    [Header("Rotate")]
    [SerializeField] private Transform _head0;
    [SerializeField] private float _sensetivity;

    public float speed;

    void Start()
    {
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
        bool forward = Input.GetKey(KeyCode.W);
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
        }
    }

    private void Rotate()
    {
        float rotationY = Input.GetAxis("Mouse X") * _sensetivity;
        float rotationX = Input.GetAxis("Mouse Y") * _sensetivity;
        transform.Rotate(0, rotationY, 0);
        _head0.Rotate(-rotationX, 0, 0);
    }
}
