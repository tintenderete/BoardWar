using UnityEngine;
using System.Collections;
using BoardGameApi;

public class NewTurn : IStep
{

	go_Canvas canvasControl;
	PlayerInputs inputs;

	public NewTurn()
	{
		canvasControl = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
	}
	
	public void UpdateStep(TurnManager turnManager)
	{
		canvasControl.ResetManaText ();
		inputs.CleanInputs ();

		string msj = turnManager.GetGame().GetCurrentPlayerName ();
		Curtain.On (1.5f, msj);

		Player.mana = 10;

		turnManager.NextStep<PlayerPlay> ();
	}
}
