using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class LookForMovements: MonoBehaviour
{
	private static PlayerInputs inputs = ScriptableObject.CreateInstance<PlayerInputs> ();
	public static Action newMovement;

	static public Action Look(Board board, Player currentPlayer)
	{
		
		
		if (PlayerInputs.actor_where != null && PlayerInputs.action != null) 
		{

			Cell cell = PlayerInputs.action.FindCellInDestiny (Tools_PlayerPlay.TakeActorAsCell (PlayerInputs.actor_where, board));


			if (cell != null) 
			{	
				PlayerInputs.action.destinyCells = new List<Cell>();
				PlayerInputs.action.destinyCells.Add (cell);

				newMovement = PlayerInputs.action;
				inputs.CleanInputs ();

				return newMovement;

			}
			else 
			{
				PlayerInputs.actor_where = null;
				return null;
			}
		} 
		else if (PlayerInputs.action != null) 
		{
			PlayerInputs.action.LookForMovements (currentPlayer, board);

			if (PlayerInputs.action.destinyCells.Count == 0) 
			{
				inputs.CleanInputs ();
				return null;
			} 
			else 
			{
				MarkCells (PlayerInputs.action);
			}

			return null;
		} 

		return null;
	}


	private static void MarkCells(Action action)
	{
		foreach (Cell cell in action.destinyCells) 
		{
			ListCellManager.FindCell (cell).SetStateMarkedCell (true);
		}
	}

	public static void UnMarkCells()
	{
		foreach (CellManager cellM in ListCellManager.listCell) 
		{
			cellM.SetStateMarkedCell (false);
		}
	}


}
