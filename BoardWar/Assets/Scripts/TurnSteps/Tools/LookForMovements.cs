using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class LookForMovements
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

			return null;
		} 

		return null;
	}
}
