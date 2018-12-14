using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUnlockScene : MonoBehaviour
{
    [SerializeField] private bool alreadyUnlocked = false;
    public ExampleVariableStorage variableStorage;
    public Yarn.Unity.Example.NPC npcTest;
    public GameObject scanRobot;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !alreadyUnlocked)
        {
            variableStorage.SetValue("$abrirPuerta", new Yarn.Value(true));
            scanRobot.GetComponent<Animator>().Play("TryUnlockDoor");
            alreadyUnlocked = true;
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(npcTest.talkToNode);
        }
    }
}
