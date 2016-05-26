using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class PlayerPlay : IStep 
{
	public Action nextMovement;
	PlayerInputs inputs;
	Game game;
	Board board;
	Player currentPlayer;


	public PlayerPlay()
	{
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();

	}

	public void UpdateStep(TurnManager turnManager)
	{
		Curtain.Off ();
		inputs.RightClick ();

		game = turnManager.GetGame ();
		board = game.GetBoard ();
		currentPlayer = game.GetCurrentPlayer ();

		nextMovement = LookForMovements.Look (board, currentPlayer);

		if (nextMovement != null) 
		{
			turnManager.FindOneStepLike<PlayAnimation> ().nextMovement = nextMovement;
			turnManager.NextStep<PlayAnimation>();
			nextMovement = null;
		}
	}
}
