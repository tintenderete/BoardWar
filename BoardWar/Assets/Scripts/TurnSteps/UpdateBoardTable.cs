using UnityEngine;
using System.Collections;
using BoardGameApi;

public class UpdateBoardTable : IStep 
{
	public Action nextMovement;

	public UpdateBoardTable()
	{
	}

	public void UpdateStep(TurnManager turnManager)
	{
		nextMovement.Execute (nextMovement.destinyCells [0], turnManager.GetGame ().GetBoard ());
		turnManager.GetGame ().NexPlayer ();
		turnManager.NextStep<PlayerPlay> ();
		Curtain.On (1.5f, "Next Player: " + turnManager.GetGame ().GetCurrentPlayerName () + "");

	}
}
