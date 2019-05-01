using UnityEngine.UI;
using UnityEngine;

public class ComputerOffice : Interactuable 
{
	[SerializeField] private Transform newPosition;         // Camera new position | To reposition the camera so the player can see the screen
	[SerializeField] private GameObject loginCanvas;       // Canvas in charge of the screen and the puzzles
    [SerializeField] private GameObject screenCanvas;       // Canvas in charge of the screen and the puzzles
	[Space]

	// Login values
	[SerializeField] private string userName = "TheMadScienceGuy";
	[SerializeField] private string password = "1";
	[SerializeField] private InputField loginField;
	[SerializeField] private InputField passwordField;

	// Robots
	[SerializeField] private GameObject[] robots;

	[Space]

	public ExampleVariableStorage variableStorage;

	// Components
	protected override void Start()
	{
		base.Start();

		screenCanvas = this.transform.Find("ScreenCanvas").gameObject;
		loginCanvas.SetActive(false);
		screenCanvas.SetActive(false);
	}

	
	public override void Interact()
	{
		base.Interact();
		GameMaster.GM.SetCamera(newPosition);
		loginCanvas.SetActive(true);
		loginField.text = userName;
		loginField.image.color = Color.white;
		passwordField.image.color = Color.white;
		passwordField.text = "";
		screenCanvas.SetActive(false);
	}

	public void StopInteract()
	{
		GameMaster.GM.SetCamera(newPosition);
		loginCanvas.SetActive(false);
		screenCanvas.SetActive(false);
	}

	public void CheckPassword()
	{
		Color wrongColor = new Color();
     	ColorUtility.TryParseHtmlString("#FDA4A4", out wrongColor);

		if (loginField.text.ToLower().Equals(userName.ToLower()))
		{
			loginField.image.color = Color.white;

			if (!passwordField.text.Equals(password))
			{
				passwordField.image.color = wrongColor;
				passwordField.text = "";
			}
			else
			{
				loginCanvas.SetActive(false);
				screenCanvas.SetActive(true);
			}
		}
		else
		{
			loginField.image.color = wrongColor;
			loginField.text = "";
		}
	}

	public void TurnRobotsOn()
	{
		variableStorage.SetValue("$" + "online", new Yarn.Value(true));

		foreach(GameObject idleRobot in robots)
		{
			idleRobot.GetComponent<Animator>().Play("Idle");
		}
	}
}
