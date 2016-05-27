using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class UpdateScene  : IStep 
{
	public Action nextMovement;
	public List<Cell> deadPieces;
	go_Canvas canvas;


	public UpdateScene()
	{
		deadPieces = new List<Cell> ();
		canvas = GameObject.Find ("Canvas").GetComponent<go_Canvas> ();
	}

	public void UpdateStep(TurnManager turnManager)
	{
		canvas.SkillsMenuOff ();

		if (nextMovement != null) 
		{
			AnimationFactory.ExecuteAnimation (nextMovement); 
			turnManager.FindOneStepLike<UpdateGame> ().nextMovement = nextMovement;
			nextMovement = null;
			turnManager.NextStep<UpdateGame> ();
		}

		if (deadPieces.Count != 0)
		{
			DeadAnmiations ();
			deadPieces = new List<Cell> ();
			turnManager.NextStep<UpdateGame> ();
		}

		

	}


	private void DeadAnmiations()
	{
		Piece piece;

		foreach (Cell cell in deadPieces) 
		{
			piece = cell.GetPiece ();

			foreach (PieceManager pieceManager in ListPieceManager.listPiece) 
			{
				if (pieceManager.id == piece.GetId ()) 
				{
					AnimationFactory.ExecuteAnimation (ActionFactory.MakeAction ("Dead", cell));
				}
			}
		}

	}

}
