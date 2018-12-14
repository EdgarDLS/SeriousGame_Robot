using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity.Example 
{
    public class ComputerInteract : Interactuable
    {
        [SerializeField] private Transform newPosition;         // Camera new position | To reposition the camera so the player can see the screen
        [SerializeField] private GameObject screenCanvas;       // Canvas in charge of the screen and the puzzles

        // Dialogue variables
        public ExampleVariableStorage variableStorage;
        public Yarn.Unity.Example.NPC npcTest;

        // Components
        Animator screenCanvasAnimator;


        protected override void Start()
        {
            base.Start();

            screenCanvas = this.transform.Find("ScreenCanvas").gameObject;
            screenCanvasAnimator = screenCanvas.GetComponent<Animator>();
        }

        
        public override void Interact()
        {
            base.Interact();
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.Start");
            GameMaster.GM.SetCamera(newPosition);
        }

        [YarnCommand("stopinteract")]
        public void StopInteract()
        {
            GameMaster.GM.SetCamera(newPosition);
        }

        // Tests
        [YarnCommand("startfirsttest")]
        public void StartFirstTest()
        {
            Debug.Log("TEST");
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.Incorrecto");
            //screenCanvasAnimator.Play("FirstTest");
        }
        
        [YarnCommand("startsecondtest")]
        public void StartSecondTest()
        {
            
            screenCanvasAnimator.Play("SecondTest");
        }

        public void TestFailed()
        {
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.Incorrecto");
        }

        public void CompleteFirstTest()
        {
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.CorrectoUno");
        }
    }
}
