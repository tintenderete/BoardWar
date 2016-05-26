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

		turnManager.FindOneStepLike<UpdateBoardTable> ().nextMovement = nextMovement;
		turnManager.NextStep<UpdateBoardTable> ();

	}

}
