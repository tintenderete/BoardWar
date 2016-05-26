using UnityEngine;
using System.Collections;
using BoardGameApi;

public class UpdateGame : IStep 
{
	public Action nextMovement;

	public UpdateGame()
	{
	}

	public void UpdateStep(TurnManager turnManager)
	{
		
		nextMovement.Execute (nextMovement.destinyCells [0], turnManager.GetGame ().GetBoard ());

		Player.mana = Player.mana - nextMovement.manaCost;

		if (Player.mana > 0) 
		{
			turnManager.NextStep<PlayerPlay> ();
		} 
		else 
		{

			turnManager.GetGame ().NexPlayer ();
			turnManager.NextStep<DeadPieces> ();
		}

	}



}
