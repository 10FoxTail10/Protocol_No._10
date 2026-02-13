using UnityEngine;
using System.Collections.Generic;

public class movement : MonoBehaviour
{
    [Header("Rotate")]
    [SerializeField] private Transform _head0;
    [SerializeField] private Transform _head1;
    [SerializeField] private Transform _head2;
    [SerializeField] private float _sensetivity;

    public float speed;
    public List<Camera> cameras;
    private int currentCameraIndex = 0;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        EnableCamera(0);
    }

    void Update()
    {
        Move();
        Rotate();
        CameraChange();
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
        _head1.Rotate(-rotationX, 0, 0);
        _head2.Rotate(-rotationX, 0, 0);
    }

    private void CameraChange()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Count)
            {
                currentCameraIndex = 0;
            }
            EnableCamera(currentCameraIndex);
        }
    }

    private void EnableCamera(int n)
    {
        cameras.ForEach(cam => cam.enabled = false);
        cameras[n].enabled = true;
    }
}
