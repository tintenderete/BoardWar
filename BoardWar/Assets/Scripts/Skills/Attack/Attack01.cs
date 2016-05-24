using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Attack01 : Action
{
	int range;
	float power;
	int minV;
	int minH;
	int maxV;
	int maxH;
	Position piecePosition;
	Piece piece;

	public Attack01(Cell currentCell):base(currentCell){}
	public Attack01(Cell currentCell, List<Cell> nextCells):base(currentCell, nextCells){}


	public override void LookForMovements (Player currentPlayer, Board board)
	{
		range = (int)GetRange ();
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
		power = GetPower ();

		piece = destinyCell.GetPiece ();

		piece.SetHealth (piece.GetHealth() - power);

	}


	private float GetRange()
	{
		List<SkillStats> skills = originCell.GetPiece ().GetSkills ();

		foreach (SkillStats skill in skills) 
		{
			if (skill.name == "Attack01") 
			{
				return skill.range;
			}
		}

		return 0f;
	}

	private float GetPower()
	{
		List<SkillStats> skills = originCell.GetPiece ().GetSkills ();

		foreach (SkillStats skill in skills) 
		{
			if (skill.name == "Attack01") 
			{
				return skill.power;
			}
		}

		return 0f;
	}


}
