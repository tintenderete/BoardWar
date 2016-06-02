using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class UpdateGame : IStep 
{
	public Action nextMovement;
	public List<Cell> deadPieces;

	public UpdateGame()
	{
		deadPieces = new List<Cell>();
	}

	public void UpdateStep(TurnManager turnManager)
	{
		if (Anim.IsWorking ()) 
		{
			return;
		}

		if (nextMovement != null) 
		{
			nextMovement.Execute (nextMovement.destinyCells [0], turnManager.GetGame ().GetBoard ());
			Player.mana = Player.mana - nextMovement.manaCost;
			nextMovement = null;
		}

		if (deadPieces.Count <= 0) 
		{
			deadPieces = FindDeadPieces (turnManager.GetGame ().GetBoard (), turnManager);
			if (IsBossDead(deadPieces))
			{
				turnManager.NextStep<Winner> ();
				return;
			}
			else if (deadPieces.Count > 0) 
			{
				turnManager.FindOneStepLike<UpdateScene>().deadPieces = deadPieces;
				turnManager.NextStep<UpdateScene> ();
			} 

		} 
		else 
		{
			EliminateDeadPiecesInGame (turnManager.GetGame().GetBoard().GetBoard());
			deadPieces = new List<Cell> ();
		}

		if (nextMovement == null && deadPieces.Count == 0) 
		{
			if (Player.mana > 0) 
			{
				turnManager.NextStep<PlayerPlay> ();
			}
			else 
			{
				turnManager.GetGame ().NexPlayer ();
				turnManager.NextStep<NewTurn> ();
			}
		}

	}

	private bool IsBossDead(List<Cell> deadPieces)
	{
		if (deadPieces == null) 
		{
			return true;
		}

		return false;
	}


	private List<Cell> FindDeadPieces(Board board, TurnManager turnManager)
	{
		List<Cell> list = new List<Cell>();

		foreach (Cell cell in board.GetBoard()) 
		{
			if (!cell.IsEmpty() && cell.GetPiece ().GetCurrentHealth () <= 0) 
			{
				if (cell.GetPiece ().GetName () == "Boss") 
				{
					return null;
				}

				list.Add (cell);
			}
		}

		return list;
	}

	private void EliminateDeadPiecesInGame(Cell[,] boardTable)
	{
		foreach (Cell cell in boardTable) 
		{
			if (cell.GetPiece ().GetCurrentHealth () <= 0) 
			{
				cell.SetEmptyCell ();
			}
		}
	}


}
