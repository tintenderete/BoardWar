using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BoardGameApi;

public class Dead : Action 
{

	public Dead(string name, Cell currentCell):base(name, currentCell){}
	public Dead(string name, Cell currentCell, List<Cell> nextCells):base(name, currentCell, nextCells){}


	public override void LookForMovements (Player currentPlayer, Board board)
	{
		return;
	}

	public override void Execute (Cell destinyCell, Board board)
	{
		return;
	}
}
