using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Winner : IStep 
{
	

	public void UpdateStep(TurnManager turnManager)
	{
		
		Curtain.On ( 3f ,"WINNER: " + turnManager.GetGame().GetCurrentPlayerName());

		turnManager.NextStep<Menu> ();


			

	}
}
