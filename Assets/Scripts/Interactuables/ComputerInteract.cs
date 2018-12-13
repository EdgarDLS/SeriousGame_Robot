using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteract : Interactuable
{
    [SerializeField] private Transform newPosition;
    [SerializeField] private bool interacting = false;


    protected override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        base.Interact();

        if (!interacting)
        {
            GameMaster.GM.SetNewCameraPosition(newPosition);
            interacting = true;
        }
        else if (interacting)
        {
            GameMaster.GM.SetOriginalCameraPosition();
            interacting = false;
        }
    }
}
