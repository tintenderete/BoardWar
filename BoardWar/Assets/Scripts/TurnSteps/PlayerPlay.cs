using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class PlayerPlay : IStep 
{
	public Action nextMovement;
	List<Action> inputs;
	Game game;
	Board board;
	Player currentPlayer;


	public PlayerPlay()
	{
		inputs = new List<Action> ();
	}

	public void UpdateStep(TurnManager turnManager)
	{
		Curtain.Off ();

		game = turnManager.GetGame ();
		board = game.GetBoard ();
		currentPlayer = game.GetCurrentPlayer ();
		inputs = currentPlayer.GetInputs ();

		if (inputs.Count == 1) 
		{

			inputs [0].LookForMovements (currentPlayer, board);

			if (inputs [0].destinyCells.Count == 0) 
			{
				currentPlayer.SetZeroInputs ();
				Tools.ClearList (inputs);
			}
		} 
		else if(inputs.Count == 2)
		{
			Cell cell = inputs [0].FindCellInDestiny (inputs [1].originCell);

			if (cell != null) 
			{	
				Tools.ClearListBut (cell, inputs [0].destinyCells);

				nextMovement = inputs [0];

				Tools.ClearList (inputs);
				currentPlayer.SetZeroInputs ();
			} 
			else 
			{
				Tools.ClearListBut (inputs[1], inputs);
			}
		}

		if (nextMovement != null) 
		{
			nextMovement.Execute (nextMovement.destinyCells[0], board);
			Debug.Log ("Health: " + nextMovement.destinyCells[0].GetPiece().GetHealth());
			game.NexPlayer ();
			nextMovement = null;

			Curtain.On (1.5f, "Next Player: " + game.GetCurrentPlayerName () + "");
		}
	}
}
