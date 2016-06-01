using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class UpdateScene  : IStep 
{
	public Action nextMovement;
	//FUturo refactoring : cuado cree daño en area, cambiar DeadAnimation a una anim_dead que reciva los muerto en destiny cell.
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
			canvas.SetManaText (Player.mana - nextMovement.manaCost);
			nextMovement = null;
			turnManager.NextStep<UpdateGame> ();
			LookForMovements.UnMarkCells ();
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
