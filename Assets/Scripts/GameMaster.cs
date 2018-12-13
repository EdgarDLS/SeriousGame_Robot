using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // GameMaster
    public static GameMaster GM;

    // Player
    [SerializeField] private GameObject player;

    // Camera
    [SerializeField] private Vector3 localOriginalPosition;   // Original position to return;
    [SerializeField] private Transform newPosition;             // New position to travel to
    [SerializeField] private float travelSpeed = 5f;            // Speed of the traveling
    [SerializeField] private bool cameraLerping = false;


    void Awake()
    {
        if (GM != null)
            Destroy(this.gameObject);

        else
            GM = this;
    }

    void Start()
    {
        player = GameObject.Find("Player");
        localOriginalPosition = Camera.main.transform.localPosition;
    }

    void Update()
    {
        // Camera travel
        if (cameraLerping)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newPosition.transform.position, travelSpeed * Time.deltaTime);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, newPosition.transform.rotation, travelSpeed * Time.deltaTime);
        }
    }

    public void SetNewCameraPosition(Transform _newPosition)
    {
        player.GetComponent<Controller>().enabled = false;
        Camera.main.GetComponent<FirstPersonCamera>().enabled = false;
        Camera.main.transform.parent = null;
        newPosition = _newPosition;
        cameraLerping = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SetOriginalCameraPosition()
    {
        cameraLerping = false;
        Camera.main.transform.parent = player.transform;
        Camera.main.transform.localPosition = localOriginalPosition;
        player.GetComponent<Controller>().enabled = true;
        Camera.main.GetComponent<FirstPersonCamera>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
