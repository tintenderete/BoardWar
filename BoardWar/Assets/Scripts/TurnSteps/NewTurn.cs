using UnityEngine;
using System.Collections;
using BoardGameApi;

public class NewTurn : IStep
{

	public void UpdateStep(TurnManager turnManager)
	{
		

		Curtain.On (1.5f, "Next Player: " + turnManager.GetGame ().GetCurrentPlayerName () + "");

		Player.mana = 10;

		turnManager.NextStep<PlayerPlay> ();
	}
}
