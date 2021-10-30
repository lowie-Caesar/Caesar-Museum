using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float mouseX, mouseY, xRotation = 0;
    [SerializeField] float xRotationMinClamp = -70f;
    [SerializeField] float xRotationMaxClamp = 70f;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject cameraObject;
    [SerializeField] float movementSpeed = 250f;
    [SerializeField] float rotationSpeed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rb = playerObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddRelativeForce(Vector3.left * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            rb.AddRelativeForce(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * movementSpeed * Time.deltaTime);
        }
    }

        void RotatePlayer()
    {
        mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xRotationMinClamp, xRotationMaxClamp);

        cameraObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(0, mouseX, 0);
    }
}
