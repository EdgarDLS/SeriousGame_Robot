using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yarn.Unity.Example 
{
	public class RobotTalkCheck : MonoBehaviour 
	{
		public ExampleVariableStorage variableStorage;
		public string variableToStore = "allRobotsChat";
		[Space]
		public string assassinAI = "SeguridadAsesina.Start";
		public ComputerInteract puertaSeguridad;
		public ComputerInteract2 puertaOficina;
		[Space]
		public Animator fadeCanvas;
		[Space]

		[SerializeField] private bool robot1Talk = false;
		[SerializeField] private bool robot2Talk = false;
		[SerializeField] private bool robot3Talk = false;
		[SerializeField] private bool robot4Talk = false;

		
		[YarnCommand("robot1Talk")]
        public void Robot1Talk()
        {
			robot1Talk = true;
			CheckRobotChatState();
        }

		[YarnCommand("robot2Talk")]
        public void Robot2Talk()
        {
			robot2Talk = true;
			CheckRobotChatState();
        }

		[YarnCommand("robot3Talk")]
        public void Robot3Talk()
        {
			robot3Talk = true;
			CheckRobotChatState();
        }

		[YarnCommand("robot4Talk")]
        public void Robot4Talk()
        {
			robot4Talk = true;

			CheckRobotChatState();
        }

		[YarnCommand("setAI")]
        public void SetAI()
        {
			puertaOficina.dialogueStartName = assassinAI;
			puertaSeguridad.dialogueStartName = assassinAI;
        }

		[YarnCommand("byebye")]
		public void CloseEyes()
		{
			fadeCanvas.Play("Exit");
			GameMaster.GM.ByeLife();
		}

		private void CheckRobotChatState()
		{
			if (robot1Talk && robot1Talk && robot1Talk && robot1Talk)
			{
				variableStorage.SetValue("$" + variableToStore, new Yarn.Value(true));
			}
		}
	}
}
