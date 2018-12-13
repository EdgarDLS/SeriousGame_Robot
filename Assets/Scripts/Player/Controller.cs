using UnityEngine;

public class Controller : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float movementSpeed = 10f;
    [Space]

    //Interactuables
    [SerializeField] private float maxInteractDistance; // Distancia maxima que se puede usar la E para interactuar
    [SerializeField] private GameObject rayObject;
    [Space]

    // Camera
    [SerializeField] Camera mainCamera;
    [Space]

    // Components | Scripts
    Rigidbody myRigidbody;


    void Start()
    {
        myRigidbody = this.transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        Vector3 lateralMovement = transform.right * movX;
        Vector3 forwardMovement = transform.forward * movZ;

        Vector3 movementInput = (lateralMovement + forwardMovement).normalized * movementSpeed;

        if (movementInput != Vector3.zero) Move(movementInput);

        RaycastHit hit;
        Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * maxInteractDistance, Color.yellow);
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, maxInteractDistance))
        {
            Debug.Log("NO IF: " + hit.transform.name);
            if (hit.transform.tag.Equals("Interactuable"))
            {
                rayObject = hit.transform.gameObject;
                rayObject.GetComponent<IInteractuable>().ShowIcon();
                Debug.Log("IF: " + hit.transform.name);
            }
        }

        if (rayObject != null)
        {
            Debug.Log("Distance: " + Vector3.Distance(this.transform.position, rayObject.transform.position));
            if (Vector3.Distance(this.transform.position, rayObject.transform.position) > 2.8f)
            {
                rayObject.GetComponent<IInteractuable>().Deinteract();
                rayObject = null;
            }
        }

        if (rayObject != null && Input.GetKeyDown(KeyCode.E))
            rayObject.GetComponent<IInteractuable>().Interact();
    }

    private void Move(Vector3 _movementInput)
    {
        myRigidbody.MovePosition(myRigidbody.position + _movementInput * Time.deltaTime);
    }
}