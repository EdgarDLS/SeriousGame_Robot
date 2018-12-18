using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity.Example 
{
    public class ComputerInteract : Interactuable
    {
        [SerializeField] private Transform newPosition;         // Camera new position | To reposition the camera so the player can see the screen
        [SerializeField] private GameObject screenCanvas;       // Canvas in charge of the screen and the puzzles
        [Space]
        [SerializeField] private GameObject testCanvas1;        // Test canvas one
        [SerializeField] private GameObject testCanvas2;        // Test canvas two
        [Space]
        [SerializeField]private Animator doorAnimator;


        // Dialogue variables
        public ExampleVariableStorage variableStorage;
        public string dialogueStartName = "PuertaSeguridad.Start";

        // Components
        Animator screenCanvasAnimator;


        protected override void Start()
        {
            base.Start();

            screenCanvas = this.transform.Find("ScreenCanvas").gameObject;
            screenCanvasAnimator = screenCanvas.GetComponent<Animator>();
            screenCanvas.SetActive(false);

            if (testCanvas1 != null) testCanvas1.SetActive(false);
            if (testCanvas2 != null) testCanvas2.SetActive(false);
        }

        
        public override void Interact()
        {
            base.Interact();
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue(dialogueStartName);
            GameMaster.GM.SetCamera(newPosition);
            screenCanvas.SetActive(true);
            if (testCanvas1 != null) testCanvas1.SetActive(false);
            if (testCanvas2 != null) testCanvas2.SetActive(false);
        }

        [YarnCommand("stopinteract")]
        public void StopInteract()
        {
            GameMaster.GM.SetCamera(newPosition);
            screenCanvas.SetActive(false);
            if (testCanvas1 != null) testCanvas1.SetActive(false);
            if (testCanvas2 != null) testCanvas2.SetActive(false);
        }

        // Tests
        [YarnCommand("startfirsttest")]
        public void StartFirstTest()
        {
            //FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.Incorrecto");
            screenCanvas.SetActive(false);
            testCanvas1.SetActive(true);
            testCanvas2.SetActive(false);
            //screenCanvasAnimator.Play("FirstTest");
        }
        
        [YarnCommand("startsecondtest")]
        public void StartSecondTest()
        {
            screenCanvas.SetActive(false);
            testCanvas1.SetActive(false);
            testCanvas2.SetActive(true);
        }

        public void TestFailed()
        {
            screenCanvas.SetActive(true);
            testCanvas1.SetActive(false);
            testCanvas2.SetActive(false);
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.Incorrecto");
        }

        public void CompleteFirstTest()
        {
            screenCanvas.SetActive(true);
            testCanvas1.SetActive(false);
            testCanvas2.SetActive(false);
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.CorrectoUno");
        }

        public void CompleteSecondTest()
        {
            Debug.Log("COMPLETADO");
            screenCanvas.SetActive(true);
            testCanvas1.SetActive(false);
            testCanvas2.SetActive(false);
            FindObjectOfType<Yarn.Unity.DialogueRunner>().StartDialogue("PuertaSeguridad.CorrectoDos");
        }

        [YarnCommand("openthegate")]
        public void OpenTheGate()
        {
            StopInteract();
            doorAnimator.Play("Open");
        }
    }
}
