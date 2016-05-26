using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class UpdateScene  : IStep 
{
	public Action nextMovement;
	go_Canvas canvas;


	public UpdateScene()
	{
		canvas = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
	}
	public void UpdateStep(TurnManager turnManager)
	{
		canvas.SkillsMenuOff ();

		if (AnimationFactory.ExecuteAnimation (nextMovement)) 
		{
			return;
		}


		turnManager.FindOneStepLike<UpdateGame> ().nextMovement = nextMovement;
		turnManager.NextStep<UpdateGame> ();

	}




}
