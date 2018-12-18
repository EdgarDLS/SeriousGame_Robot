using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUnlockScene : MonoBehaviour
{
    [SerializeField] private bool alreadyTriggered = false;
    public ExampleVariableStorage variableStorage;
    public Yarn.Unity.Example.NPC npcTest;
    public GameObject scanRobot;
    public Animator animator;
    public string variableToStore;
    public string animationToPlay;
    public string startingNode;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !alreadyTriggered)
        {
            if (variableToStore != null) variableStorage.SetValue("$" + variableToStore, new Yarn.Value(true));
            if (animationToPlay != null) animator.Play(animationToPlay);
            alreadyTriggered = true;
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(startingNode);
        }
    }
}
