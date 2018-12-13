using UnityEngine;

public class Controller : MonoBehaviour
{
    // Movement variables
    [SerializeField] private float movementSpeed = 10f;
    [Space]

    // Components | Scripts
    Rigidbody myRigidbody;


    void Start()
    {
        myRigidbody = this.transform.GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movement
        float movX = Input.GetAxisRaw("Horizontal");
        float movZ = Input.GetAxisRaw("Vertical");

        Vector3 lateralMovement = transform.right * movX;
        Vector3 forwardMovement = transform.forward * movZ;

        Vector3 movementInput = (lateralMovement + forwardMovement).normalized * movementSpeed;

        if (movementInput != Vector3.zero) Move(movementInput);
    }

    private void Move(Vector3 _movementInput)
    {
        myRigidbody.MovePosition(myRigidbody.position + _movementInput * Time.deltaTime);
    }
}