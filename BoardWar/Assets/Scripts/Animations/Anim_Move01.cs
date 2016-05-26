using UnityEngine;
using System.Collections;
using BoardGameApi;

public class Anim_Move01 
{
	private static GameObject pieceToMove;
	private static Position newPosition;

	public static void Execute(Action action )
	{
		newPosition = action.destinyCells [0].GetBoardPosition();

		pieceToMove = FindGameObject (action);

		pieceToMove.transform.position = new Vector3 (
			newPosition.horizontal,
			pieceToMove.transform.position.y,
			newPosition.vertical
		);
	}


	private static GameObject FindGameObject(Action action)
	{
		//Debug.Log (action.originCell.GetPiece().GetId ());
		foreach (PieceManager piece in ListPieceManager.listPiece) 
		{
			//Debug.Log (piece.id); // Existe
			if (piece.id == action.originCell.GetPiece().GetId ()) 
			{
				return piece.go;
			}
		}

		return null;
	}
}
