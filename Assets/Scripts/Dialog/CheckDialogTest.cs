using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialogTest : MonoBehaviour
{
    public Yarn.Unity.Example.NPC npcTest;
    public GameObject dialogCanvas;
    public ExampleVariableStorage variableStorage;

    [Space]
    public bool clueValue = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            clueValue = !clueValue;
            variableStorage.SetValue("$ClueFound", new Yarn.Value(clueValue));
            Debug.Log(variableStorage.GetValue("$ClueFound"));
        }

        else if (Input.anyKeyDown && !dialogCanvas.active)
        {
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(npcTest.talkToNode);
        }
    }
}
