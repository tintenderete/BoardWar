using UnityEngine;
using System.Collections;
using BoardGameApi;

public class PlayAnimation  : IStep 
{
	public Action nextMovement;
	go_Canvas canvas;

	public PlayAnimation()
	{
		canvas = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
	}
	public void UpdateStep(TurnManager turnManager)
	{
		canvas.SkillsMenuOff ();

		AnimationFactory.ExecuteAnimation (nextMovement);

		nextMovement.Execute (nextMovement.destinyCells[0], turnManager.GetGame().GetBoard());
		//Debug.Log ("Health: " + nextMovement.destinyCells[0].GetPiece().GetHealth());
		turnManager.GetGame().NexPlayer ();
		Curtain.On (1.5f, "Next Player: " + turnManager.GetGame().GetCurrentPlayerName () + "");

		turnManager.NextStep<PlayerPlay> ();

	}

}
