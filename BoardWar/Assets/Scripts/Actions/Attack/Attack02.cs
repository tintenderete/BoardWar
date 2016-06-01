using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Attack02 : Attack01 
{

	public Attack02(string name,Cell currentCell):base(name, currentCell)
	{

	}
	public Attack02(string name, Cell currentCell, List<Cell> nextCells):base(name, currentCell, nextCells)
	{

	}

	public override void LookForMovements (Player currentPlayer, Board board)
	{
		base.LookForMovements(currentPlayer, board);
	}

	public override void Execute (Cell destinyCell, Board board)
	{
		base.Execute (destinyCell, board);
	}
}
