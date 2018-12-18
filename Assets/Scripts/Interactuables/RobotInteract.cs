using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotInteract : Interactuable
{
    [SerializeField] private  Yarn.Unity.Example.NPC startingNode;

    public override void Interact()
        {
            base.Interact();
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(startingNode.talkToNode);
        }
}
