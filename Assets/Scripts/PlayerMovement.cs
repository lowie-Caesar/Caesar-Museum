using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float MovementSpeed = 7.5f;
    //[SerializeField] float RotationSpeed = 7.5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
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
            rb.AddRelativeForce(Vector3.left * MovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * MovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            Debug.Log("Forward");
            rb.AddRelativeForce(Vector3.forward * MovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * MovementSpeed * Time.deltaTime);
        }
    }

        void RotatePlayer()
    {
        float xValue = Input.GetAxis("Mouse Y");
        float yValue = Input.GetAxis("Mouse X");

        transform.Rotate(0, yValue, 0);
    }
}
