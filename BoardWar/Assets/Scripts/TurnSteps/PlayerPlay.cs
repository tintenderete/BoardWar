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
	Timer timer;

	public PlayerPlay()
	{
		inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
		timer = new Timer (10000f);
	}

	public void UpdateStep(TurnManager turnManager)
	{
		Curtain.Off ();
		inputs.RightClick ();

		CheckTime (turnManager);

		game = turnManager.GetGame ();
		board = game.GetBoard ();
		currentPlayer = game.GetCurrentPlayer ();


		nextMovement = LookForMovements.Look (board, currentPlayer);

		if (PlayerInputs.action != null &&
			PlayerInputs.action.manaCost > Player.mana) 
		{
			inputs.CleanInputs ();
		}
		else if (nextMovement != null) 
		{
			turnManager.FindOneStepLike<UpdateScene> ().nextMovement = nextMovement;
			turnManager.NextStep<UpdateScene>();
			nextMovement = null;
		}
	}

	private void CheckTime(TurnManager turnManager)
	{
		if (timer.TimeOff ()) 
		{
			turnManager.NextStep<NewTurn> ();
			timer.ResetTime ();
		}
	}




}
