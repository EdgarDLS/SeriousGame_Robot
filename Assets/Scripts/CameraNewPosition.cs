using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNewPosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform newPosition;
    [SerializeField] private float travelSpeed = 5f;

    private bool cameraNewPosition = false;


    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !cameraNewPosition)
        {
            GameMaster.GM.SetNewCameraPosition(newPosition);
            cameraNewPosition = true;
        }

        else if (Input.GetKeyDown(KeyCode.E) && cameraNewPosition)
        {
            GameMaster.GM.SetOriginalCameraPosition();
            cameraNewPosition = false;
        }
    }
}
