using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] Camera mainCamera;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * -movementSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.GetComponent<Rigidbody>().AddForce(mainCamera.transform.right * movementSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.GetComponent<Rigidbody>().AddForce(mainCamera.transform.right * -movementSpeed);
        }
    }
}