using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    //Interactuables
    [SerializeField] private float maxInteractDistance = 2f;    // Distancia maxima que se puede usar la E para interactuar
    [SerializeField] private float maxInteractOutDistance = 3f; // Distancia maxima que se puede usar la E para interactuar
    [SerializeField] private GameObject rayObject;


    // Update is called once per frame
    void Update ()
    {
        // Interactuable
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * maxInteractDistance, Color.yellow);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxInteractDistance))
        {
            Debug.Log("NO IF: " + hit.transform.name);
            if (hit.transform.tag.Equals("Interactuable"))
            {
                if (rayObject != null && rayObject != hit.transform.gameObject)
                {
                    RemoveInteractuable();
                }

                rayObject = hit.transform.gameObject;
                rayObject.GetComponent<IInteractuable>().ShowIcon();
                Debug.Log("IF: " + hit.transform.name);
            }
        }

        if (rayObject != null)
        {
            Debug.Log("Distance: " + Vector3.Distance(this.transform.position, rayObject.transform.position));
            if (Vector3.Distance(this.transform.position, rayObject.transform.position) > maxInteractOutDistance)
            {
                RemoveInteractuable();
            }
        }

        if (rayObject != null && Input.GetKeyDown(KeyCode.E))
            rayObject.GetComponent<IInteractuable>().Interact();
    }


    private void RemoveInteractuable()
    {
        rayObject.GetComponent<IInteractuable>().Deinteract();
        rayObject = null;
    }
}
