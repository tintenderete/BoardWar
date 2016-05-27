using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Attack01 : Action
{
	
	int minV;
	int minH;
	int maxV;
	int maxH;
	Position piecePosition;
	Piece piece;

	public Attack01(string name,Cell currentCell):base(name, currentCell)
	{
		
	}
	public Attack01(string name, Cell currentCell, List<Cell> nextCells):base(name, currentCell, nextCells)
	{
		
	}


	public override void LookForMovements (Player currentPlayer, Board board)
	{
		
		piecePosition = originCell.GetBoardPosition ();

		minV = (int)piecePosition.vertical - range;
		minH = (int)piecePosition.horizontal - range;
		maxV = (int)piecePosition.vertical + range;
		maxH = (int)piecePosition.horizontal + range;

		for(int v = minV; v <= maxV ; v++ )
		{
			for(int h = minH; h <= maxH ; h++ )
			{
				if (!board.IsPosOnTheBoard (new Position (h, v)))
				{
				}
				else if (board.GetCell (h, v).IsEmpty ()) 
				{
				} 
				else if(board.IsPlayerPiece (board.GetCell (h, v), currentPlayer))
				{
				}
				else 
				{ 
					destinyCells.Add (board.GetCell (h, v));
				}
				
			}
		}
	}

	public override void Execute (Cell destinyCell, Board board)
	{
		

		piece = destinyCell.GetPiece ();

		piece.SetHealth (piece.GetHealth() - power);

	}






}
