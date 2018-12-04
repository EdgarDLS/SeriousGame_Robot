using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour, IInteractuable
{
    [SerializeField] private List<string> dialog = new List<string>();

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
