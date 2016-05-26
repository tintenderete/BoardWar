using UnityEngine;
using System.Collections;
using BoardGameApi;

public class DeadPieces : IStep 
{
	Cell[,] boardTable;

	public void UpdateStep(TurnManager turnManager)
	{

		boardTable = turnManager.GetGame ().GetBoard ().GetBoard ();

		EliminateDeadPiecesInScene (boardTable);
		EliminateDeadPiecesInGame (boardTable);

		turnManager.NextStep<NewTurn> ();

	}

	private void EliminateDeadPiecesInScene(Cell[,] boardTable)
	{
		Piece piece;

		foreach (Cell cell in boardTable) 
		{
			piece = cell.GetPiece ();

			if (piece.GetHealth () <= 0) 
			{
				foreach (PieceManager pieceManager in ListPieceManager.listPiece) 
				{
					if (pieceManager.id == piece.GetId ()) 
					{
						pieceManager.go.SetActive (false);
					}
				}
			}
		}
	}

	private void EliminateDeadPiecesInGame(Cell[,] boardTable)
	{
		foreach (Cell cell in boardTable) 
		{
			if (cell.GetPiece ().GetHealth () <= 0) 
			{
				cell.SetEmptyCell ();
			}
		}
	}
}
