using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // GameMaster
    public static GameMaster GM;

    // Dialogue System
    [SerializeField] private bool dialogueTalking = false;                  // To enable or disable the components so the player cant move while something or anyone is talking
    [Space]

    // Player
    [SerializeField] private GameObject player;
    [Space]

    // Camera
    [SerializeField] private bool inPlayerHead = true;                      // if true then its working as should | if not true it means it is aiming to something, like a terminal
    [SerializeField] private Vector3 localOriginalPosition;                 // Original position to return
    [SerializeField] private Transform newPosition;                         // New position to travel to
    [SerializeField] private float travelSpeed = 5f;                        // Speed of the traveling
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

    // Function that will be called when the Dialogue system is working to avoid the player moving.
    public void SilencePlease()
    {
        dialogueTalking = !dialogueTalking;

        player.GetComponent<Controller>().enabled = !dialogueTalking;
        Camera.main.GetComponent<FirstPersonCamera>().enabled = !dialogueTalking;
        player.GetComponent<PlayerInteraction>().enabled = !dialogueTalking;

        Cursor.visible = dialogueTalking;
        
        if (dialogueTalking)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }


    // Interaction funcionts | Set camera position and enable and disable some scripts to avoid the movement.
    public void SetCamera(Transform _newPosition)
    {
        if (inPlayerHead)
            SetNewCameraPosition(_newPosition);
        else
            SetOriginalCameraPosition();
        
        inPlayerHead = !inPlayerHead;
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
